using System;
using System.Collections.Generic;

namespace SushiBarFileImplement.Models
{
    public class StorageFacility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerFLM { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, int> StorageFacilityIngredients { get; set; }
    }
}