using SushiBarBusinessLogic.OfficePackage;
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
        private readonly IStorageFacilityStorage _sorageFacilityStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(IDishStorage dishStorage, IIngredientStorage ingredientStorage,
        IOrderStorage orderStorage, IStorageFacilityStorage sorageFacilityStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord,  AbstractSaveToPdf saveToPdf)
        {
            _dishStorage = dishStorage;
            _ingredientStorage = ingredientStorage;
            _orderStorage = orderStorage;
            _sorageFacilityStorage = sorageFacilityStorage;
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
                foreach (var ingredient in dish.DishIngredients)
                {
                    record.Ingredients.Add(new Tuple<string, int>(ingredient.Value.Item1, ingredient.Value.Item2));
                    record.TotalCount += ingredient.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка ингридиентов с указанием, на каких складах лежат
        /// </summary>
        /// <returns></returns>
        public List<ReportStorageFacilityIngredientsViewModel> GetStorageFacilityIngredient()
        {
            var storageFacilities = _sorageFacilityStorage.GetFullList();
            var records = new List<ReportStorageFacilityIngredientsViewModel>();

            foreach (var storageFacility in storageFacilities)
            {
                var record = new ReportStorageFacilityIngredientsViewModel
                {
                    StorageFacilityName = storageFacility.Name,
                    TotalCount = 0,
                    Ingredients = new List<Tuple<string, int>>(),
                };

                foreach (var ingredient in storageFacility.StorageFacilityIngredients)
                {
                    record.Ingredients.Add(new Tuple<string, int>(
                    ingredient.Value.Item1, ingredient.Value.Item2));
                    record.TotalCount += ingredient.Value.Item2;
                }
                records.Add(record);
            }
            return records;
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
        /// Получение списка кол-ва заказов на дату
        /// </summary>
        /// <returns></returns>
        public List<ReportOrdersDateViewModel> GetOrdersDate()
        {
            return _orderStorage.GetFullList()
            .GroupBy(rec => rec.DateCreate.ToShortDateString())
            .Select(x => new ReportOrdersDateViewModel
            {
                DateCreate = Convert.ToDateTime(x.Key),
                Count = x.Count(),
                Sum = x.Sum(rec => rec.Sum)
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
        /// Сохранение складов в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveStorageFacilitiesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateTableDoc(new WordStorageFacilityInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                StorageFacilities = _sorageFacilityStorage.GetFullList()
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
                Title = "Список блюд и ингредиентов",
                DishIngredients = GetDishIngredient()
            });
        }
        /// <summary>
        /// Сохранение ингредиентов с указаеним складов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveStorageFacilityIngredientsToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateStorageFacilityReport(new ExcelStorageFacilityInfo
            {
                FileName = model.FileName,
                Title = "Список складов и ингредиентов",
                StorageFacilityIngredients = GetStorageFacilityIngredient()
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
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersDateToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDocOrdersDate(new PdfOrdersDateInfo
            {
                FileName = model.FileName,
                Title = "Список количества заказов по датам",
                OrdersDate = GetOrdersDate()
            });
        }
    }
}
