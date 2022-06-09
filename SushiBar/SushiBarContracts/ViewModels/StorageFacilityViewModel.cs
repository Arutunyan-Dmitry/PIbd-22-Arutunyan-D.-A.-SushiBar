using System;
using System.Collections.Generic;
using SushiBarContracts.Attributes;

namespace SushiBarContracts.ViewModels
{
    public class StorageFacilityViewModel
    {
        [Column(title: "Номер", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int Id { get; set; }
        [Column(title: "Название склада", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Name { get; set; }
        [Column(title: "ФИО ответственного", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string OwnerFLM { get; set; }
        [Column(title: "Дата создания", format: "dd/MM/yyyy", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorageFacilityIngredients { get; set; }
    }
}
