using System;
using System.Collections.Generic;

namespace SushiBarContracts.BindingModels
{
    /// <summary>
    /// Склад с хранящимися на нём ингридиентами
    /// </summary>
    public class StorageFacilityBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string OwnerFLM { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorageFacilityIngredients { get; set; }
    }
}
