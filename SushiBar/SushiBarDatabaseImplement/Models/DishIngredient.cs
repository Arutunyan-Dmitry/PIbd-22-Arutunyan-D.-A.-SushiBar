using System.ComponentModel.DataAnnotations;

namespace SushiBarDatabaseImplement.Models
{
    public class DishIngredient
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
