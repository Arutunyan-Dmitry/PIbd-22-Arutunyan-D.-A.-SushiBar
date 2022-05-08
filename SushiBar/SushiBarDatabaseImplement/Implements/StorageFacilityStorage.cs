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
    public class StorageFacilityStorage : IStorageFacilityStorage
    {
        public List<StorageFacilityViewModel> GetFullList()
        {
            using var context = new SushiBarDatabase();
            return context.StorageFacilities
            .Include(rec => rec.StorageFacilityIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<StorageFacilityViewModel> GetFilteredList(StorageFacilityBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SushiBarDatabase();
            return context.StorageFacilities
            .Include(rec => rec.StorageFacilityIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .Where(rec => rec.Name.Contains(model.Name))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public StorageFacilityViewModel GetElement(StorageFacilityBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SushiBarDatabase();
            var storage = context.StorageFacilities
            .Include(rec => rec.StorageFacilityIngredients)
            .ThenInclude(rec => rec.Ingredient)
            .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
            return storage != null ? CreateModel(storage) : null;
        }
        public void Insert(StorageFacilityBindingModel model)
        {
            using var context = new SushiBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                StorageFacility storageFacility = new StorageFacility()
                {
                    Name = model.Name,
                    OwnerFLM = model.OwnerFLM,
                    DateCreate = model.DateCreate
                };
                context.StorageFacilities.Add(storageFacility);
                context.SaveChanges();
                CreateModel(model, storageFacility, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(StorageFacilityBindingModel model)
        {
            using var context = new SushiBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.StorageFacilities.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(StorageFacilityBindingModel model)
        {
            using var context = new SushiBarDatabase();
            StorageFacility element = context.StorageFacilities.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.StorageFacilities.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public bool TakeIngredientFromStore(Dictionary<int, (string, int)> ingredients, int dishNumb)
        {
            using var context = new SushiBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var ingredient in ingredients)
                {
                    int requiredIngredientCount = ingredient.Value.Item2 * dishNumb;
                    var storageFacilityIngredients = context.StorageFacilityIngredients
                        .Where(storageFacility => storageFacility.IngredientId == ingredient.Key);

                    foreach (var storageFacilityIngredient in storageFacilityIngredients)
                    {
                        if (storageFacilityIngredient.Count <= requiredIngredientCount)
                        {
                            requiredIngredientCount -= storageFacilityIngredient.Count;
                            context.StorageFacilityIngredients.Remove(storageFacilityIngredient);
                        }
                        else
                        {
                            storageFacilityIngredient.Count -= requiredIngredientCount;
                            requiredIngredientCount = 0;
                            break;
                        }
                    }
                    if (requiredIngredientCount != 0)
                    {
                        throw new Exception("Ингредиентов на складе недостаточно");
                    }
                }
                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
        private static StorageFacility CreateModel(StorageFacilityBindingModel model, StorageFacility storageFacility, SushiBarDatabase context)
        {
            storageFacility.Name = model.Name;
            storageFacility.OwnerFLM = model.OwnerFLM;
            if (model.Id.HasValue)
            {
                var storageFacilityIngredients = context.StorageFacilityIngredients
                    .Where(rec => rec.StorageFacilityId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.StorageFacilityIngredients.RemoveRange(storageFacilityIngredients.Where(rec =>
               !model.StorageFacilityIngredients.ContainsKey(rec.IngredientId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateIngredient in storageFacilityIngredients)
                {
                    updateIngredient.Count =
                    model.StorageFacilityIngredients[updateIngredient.IngredientId].Item2;
                    model.StorageFacilityIngredients.Remove(updateIngredient.IngredientId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var si in model.StorageFacilityIngredients)
            {
                context.StorageFacilityIngredients.Add(new StorageFacilityIngredient
                {
                    StorageFacilityId = storageFacility.Id,
                    IngredientId = si.Key,
                    Count = si.Value.Item2
                });
                context.SaveChanges();
            }
            return storageFacility;
        }
        private static StorageFacilityViewModel CreateModel(StorageFacility storageFacility)
        {
            return new StorageFacilityViewModel
            {
                Id = storageFacility.Id,
                Name = storageFacility.Name,
                OwnerFLM = storageFacility.OwnerFLM,
                DateCreate = storageFacility.DateCreate,
                StorageFacilityIngredients = storageFacility.StorageFacilityIngredients
            .ToDictionary(recSI => recSI.IngredientId,
            recSI => (recSI.Ingredient?.IngredientName, recSI.Count))
            };
        }
    }
}
