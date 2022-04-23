using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelStorageFacilityInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportStorageFacilityIngredientsViewModel> StorageFacilityIngredients { get; set; }
    }
}
