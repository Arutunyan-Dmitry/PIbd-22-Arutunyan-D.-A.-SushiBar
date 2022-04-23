using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.OfficePackage.HelperModels
{
    public class PdfOrdersDateInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportOrdersDateViewModel> OrdersDate { get; set; }
    }
}
