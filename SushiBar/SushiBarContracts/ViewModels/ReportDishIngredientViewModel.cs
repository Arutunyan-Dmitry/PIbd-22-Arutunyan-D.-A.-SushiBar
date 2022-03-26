using System;
using System.Collections.Generic;

namespace SushiBarContracts.ViewModels
{
    public class ReportDishIngredientViewModel
    {
        public string DishName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Ingredients { get; set; }
    }
}
