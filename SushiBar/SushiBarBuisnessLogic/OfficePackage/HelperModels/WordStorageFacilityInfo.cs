using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.OfficePackage.HelperModels
{
    public class WordStorageFacilityInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<StorageFacilityViewModel> StorageFacilities { get; set; }
    }
}
