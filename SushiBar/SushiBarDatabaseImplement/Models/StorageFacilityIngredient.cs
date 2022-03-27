using System.ComponentModel.DataAnnotations;

namespace SushiBarDatabaseImplement.Models
{
    public class StorageFacilityIngredient
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int StorageFacilityId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual StorageFacility StorageFacility { get; set; }
    }
}
