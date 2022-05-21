namespace SushiBarFileImplement.Models
{
    /// <summary>
    /// Исполнитель
    /// </summary>
    public class Implementer
    {
        public int Id { get; set; }
        public string ImplementerFLM { get; set; }
        public int WorkingTime { get; set; }
        public int PauseTime { get; set; }
    }
}
