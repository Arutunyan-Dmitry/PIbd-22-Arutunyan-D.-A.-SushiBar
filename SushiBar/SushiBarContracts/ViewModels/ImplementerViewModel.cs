using SushiBarContracts.Attributes;

namespace SushiBarContracts.ViewModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class ImplementerViewModel
    {
        public int Id { get; set; }
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFLM { get; set; }
        [Column(title: "Время на заказ", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int WorkingTime { get; set; }
        [Column(title: "Время на перерыв", gridViewAutoSize: GridViewAutoSize.Fill)]
        public int PauseTime { get; set; }
    }
}
