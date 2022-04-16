﻿using SushiBarContracts.BindingModels;
using SushiBarContracts.StoragesContracts;
using SushiBarContracts.ViewModels;
using SushiBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SushiBarDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new SushiBarDatabase();
            return context.Orders.Include(rec => rec.Dish).ToList().Select(CreateModel).ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SushiBarDatabase();
            return context.Orders.Include(rec => rec.Dish)
                .Where(rec => rec.DishId == model.DishId)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new SushiBarDatabase();
            var order = context.Orders.Include(rec => rec.Dish)
                .FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            using var context = new SushiBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(OrderBindingModel model)
        {
            using var context = new SushiBarDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using var context = new SushiBarDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.DishId = model.DishId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private static OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                DishId = order.DishId,
                DishName = order.Dish.DishName,
                Count = order.Count,
                Sum = order.Sum,
                Status = Enum.GetName(order.Status),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
