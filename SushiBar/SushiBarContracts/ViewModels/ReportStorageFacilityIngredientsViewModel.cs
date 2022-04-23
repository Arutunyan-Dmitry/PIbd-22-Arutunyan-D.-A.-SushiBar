using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiBarContracts.ViewModels
{
    public class ReportStorageFacilityIngredientsViewModel
    {
        public string StorageFacilityName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Ingredients { get; set; }
    }
}
