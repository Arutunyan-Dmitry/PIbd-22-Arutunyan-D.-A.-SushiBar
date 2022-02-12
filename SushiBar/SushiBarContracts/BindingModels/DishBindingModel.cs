using System.Collections.Generic;

namespace SushiBarContracts.BindingModels
{
    /// <summary>
    /// Блюдо, приготавливаемое в суши-баре
    /// </summary>
    public class DishBindingModel
    {
        public int? Id { get; set; }
        public string DishName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> DishIngredients { get; set; }
    }
}
