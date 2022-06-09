using System.Collections.Generic;
using SushiBarContracts.Attributes;

namespace SushiBarContracts.ViewModels
{
    /// <summary>
    /// Блюдо, приготавливаемое в суши-баре
    /// </summary>
    public class DishViewModel
    {
        public int Id { get; set; }
        [Column(title: "Название блюда", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DishName { get; set; }
        [Column(title: "Цена", format: "c1", gridViewAutoSize: GridViewAutoSize.Fill)]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> DishIngredients { get; set; }
    }
}
