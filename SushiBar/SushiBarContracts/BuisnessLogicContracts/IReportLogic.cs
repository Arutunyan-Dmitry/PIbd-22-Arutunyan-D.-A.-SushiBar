using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarContracts.BuisnessLogicContracts
{
    public interface IReportLogic
    {
        /// <summary>
        /// Получение списка ингредиентов с указанием, в каких блюдах используются
        /// </summary>
        /// <returns></returns>
        List<ReportDishIngredientViewModel> GetDishIngredient();
        /// <summary>
        /// Получение списка складов с указанием, какие ингредиенты на них находятся
        /// </summary>
        /// <returns></returns>
        List<ReportStorageFacilityIngredientsViewModel> GetStorageFacilityIngredient();
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        /// <summary>
        /// Получение списка кол-ва заказов на дату
        /// </summary>
        /// <returns></returns>
        List<ReportOrdersDateViewModel> GetOrdersDate();
        /// <summary>
        /// Сохранение блюд в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveDishesToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение складов в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveStorageFacilitiesToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение блюд с указаеним ингредиентов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveDishIngredientToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение складов с указаеним ингредиентов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveStorageFacilityIngredientsToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение кол-ва заказов по датам в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersDateToPdfFile(ReportBindingModel model);
    }
}
