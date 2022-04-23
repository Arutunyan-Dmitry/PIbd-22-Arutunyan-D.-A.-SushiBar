using System;

namespace SushiBarContracts.ViewModels
{
    public class ReportOrdersDateViewModel
    {
        public DateTime DateCreate { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
