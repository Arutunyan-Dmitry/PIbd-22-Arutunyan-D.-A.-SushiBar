using SushiBarContracts.BindingModels;
using SushiBarContracts.StoragesContracts;
using SushiBarContracts.ViewModels;
using SushiBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SushiBarDatabaseImplement.Implements
{
    public class DishStorage : IDishStorage
    {
        public List<DishViewModel> GetFullList()
        {
            using var context = new SushiBarDatabase();
            return context.Dishes
            .Include(rec => rec.DishIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<DishViewModel> GetFilteredList(DishBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SushiBarDatabase();
            return context.Dishes
            .Include(rec => rec.DishIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .Where(rec => rec.DishName.Contains(model.DishName))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public DishViewModel GetElement(DishBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SushiBarDatabase();
            var dish = context.Dishes
            .Include(rec => rec.DishIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .FirstOrDefault(rec => rec.DishName == model.DishName ||
            rec.Id == model.Id);
            return dish != null ? CreateModel(dish) : null;
        }
        public void Insert(DishBindingModel model)
        {
            using var context = new SushiBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Dish dish = new Dish() 
                {
                    DishName = model.DishName,
                    Price = model.Price
                };
                context.Dishes.Add(dish);
                context.SaveChanges();
                CreateModel(model, dish, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(DishBindingModel model)
        {
            using var context = new SushiBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Dishes.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(DishBindingModel model)
        {
            using var context = new SushiBarDatabase();
            Dish element = context.Dishes.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Dishes.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Dish CreateModel(DishBindingModel model, Dish dish, SushiBarDatabase context)
        {
            dish.DishName = model.DishName;
            dish.Price = model.Price;
            if (model.Id.HasValue)
            {
                var dishIngredients = context.DishIngredients.Where(rec => rec.DishId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.DishIngredients.RemoveRange(dishIngredients.Where(rec =>
               !model.DishIngredients.ContainsKey(rec.IngredientId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateIngredient in dishIngredients)
                {
                    updateIngredient.Count =
                   model.DishIngredients[updateIngredient.IngredientId].Item2;
                    model.DishIngredients.Remove(updateIngredient.IngredientId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var di in model.DishIngredients)
            {
                context.DishIngredients.Add(new DishIngredient
                {
                    DishId = dish.Id,
                    IngredientId = di.Key,
                    Count = di.Value.Item2
                });
                context.SaveChanges();
            }
            return dish;
        }
        private static DishViewModel CreateModel(Dish dish)
        {
            return new DishViewModel
            {
                Id = dish.Id,
                DishName = dish.DishName,
                Price = dish.Price,
                DishIngredients = dish.DishIngredients
            .ToDictionary(recDI => recDI.IngredientId,
            recDI => (recDI.Ingredient?.IngredientName, recDI.Count))
            };
        }
    }
}
