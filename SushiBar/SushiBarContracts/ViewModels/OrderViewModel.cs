using SushiBarContracts.Attributes;
using System;

namespace SushiBarContracts.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFLM { get; set; }
        public int? ImplementerId { get; set; }
        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFLM { get; set; } 
        public int DishId { get; set; }
        [Column(title: "Блюдо", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DishName { get; set; }
        [Column(title: "Количество", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int Count { get; set; }
        [Column(title: "Сумма", gridViewAutoSize: GridViewAutoSize.Fill)]
        public decimal Sum { get; set; }
        [Column(title: "Статус", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Status { get; set; }
        [Column(title: "Дата создания", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", gridViewAutoSize: GridViewAutoSize.Fill)]
        public DateTime? DateImplement { get; set; }

    }
}
