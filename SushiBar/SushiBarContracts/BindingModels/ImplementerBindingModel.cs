namespace SushiBarContracts.BindingModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class ImplementerBindingModel
    {
        public int? Id { get; set; }
        public string ImplementerFLM { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
    }
}
