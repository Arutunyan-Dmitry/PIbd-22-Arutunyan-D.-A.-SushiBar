using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SushiBarDatabaseImplement.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        public string DishName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("DishId")]
        public virtual List<DishIngredient> DishIngredients { get; set; }
        [ForeignKey("DishId")]
        public virtual List<Order> Orders { get; set; }
    }
}
