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
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        /// <summary>
        /// Сохранение ингредиентов в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveDishesToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение ингредиентов с указаеним блюд в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveDishIngredientToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
