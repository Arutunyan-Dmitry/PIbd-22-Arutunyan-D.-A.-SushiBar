﻿using SushiBarBusinessLogic.OfficePackage;
using SushiBarBusinessLogic.OfficePackage.HelperModels;
using SushiBarContracts.BindingModels;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.StoragesContracts;
using SushiBarContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SushiBarBusinessLogic.BusinessLogic
{
    public class ReportLogic : IReportLogic
    {
        private readonly IIngredientStorage _ingredientStorage;
        private readonly IDishStorage _dishStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(IDishStorage dishStorage, IIngredientStorage ingredientStorage,
        IOrderStorage orderStorage, AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, 
        AbstractSaveToPdf saveToPdf)
        {
            _dishStorage = dishStorage;
            _ingredientStorage = ingredientStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }
        /// <summary>
        /// Получение списка ингридиентов с указанием, в каких блюдах используются
        /// </summary>
        /// <returns></returns>
        public List<ReportDishIngredientViewModel> GetDishIngredient()
        {
            var ingredients = _ingredientStorage.GetFullList();
            var dishes = _dishStorage.GetFullList();
            var list = new List<ReportDishIngredientViewModel>();
            foreach (var dish in dishes)
            {
                var record = new ReportDishIngredientViewModel
                {
                    DishName = dish.DishName,
                    Ingredients = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var ingredient in ingredients)
                {
                    if (dish.DishIngredients.ContainsKey(ingredient.Id))
                    {
                        record.Ingredients.Add(new Tuple<string, int>(ingredient.IngredientName, dish.DishIngredients[ingredient.Id].Item2));
                        record.TotalCount += dish.DishIngredients[ingredient.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                DishName = x.DishName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение ингредиентов в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveDishesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список блюд",
                Dishes = _dishStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение ингредиентов с указаеним блюд в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveDishIngredientToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список ингредиентов",
                DishIngredients = GetDishIngredient()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
