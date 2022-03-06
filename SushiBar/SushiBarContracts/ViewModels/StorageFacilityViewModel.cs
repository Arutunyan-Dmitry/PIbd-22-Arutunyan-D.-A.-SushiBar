using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace SushiBarContracts.ViewModels
{
    public class StorageFacilityViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string Name { get; set; }
        [DisplayName("ФИО ответственного")]
        public string OwnerFLM { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorageFacilityIngredients { get; set; }
    }
}
