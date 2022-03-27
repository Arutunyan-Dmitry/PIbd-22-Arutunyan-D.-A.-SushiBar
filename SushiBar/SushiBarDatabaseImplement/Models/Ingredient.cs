using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SushiBarDatabaseImplement.Models
{
    /// <summary>
    /// Ингредиент, требуемый для приготовления блюда
    /// </summary>
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [ForeignKey("IngredientId")]
        public virtual List<DishIngredient> DishIngredients { get; set; }

        [ForeignKey("IngredientId")]
        public virtual List<StorageFacilityIngredient> StorageFacilityIngredients { get; set; }
    }
}
