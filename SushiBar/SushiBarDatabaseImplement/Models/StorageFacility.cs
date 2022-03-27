using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SushiBarDatabaseImplement.Models
{
    public class StorageFacility
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string OwnerFLM { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("StorageFacilityId")]
        public virtual List<StorageFacilityIngredient> StorageFacilityIngredients { get; set; }
    }
}
