using System.ComponentModel;
using System.Collections.Generic;

namespace SushiBarContracts.ViewModels
{
    /// <summary>
    /// Блюдо, приготавливаемое в суши-баре
    /// </summary>
    public class DishViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название блюда")]
        public string DishName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> DishIngredients { get; set; }
    }
}
