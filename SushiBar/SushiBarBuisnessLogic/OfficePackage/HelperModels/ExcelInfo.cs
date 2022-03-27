using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDishIngredientViewModel> DishIngredients { get; set; }
    }
}