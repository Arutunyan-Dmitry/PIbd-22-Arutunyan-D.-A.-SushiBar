namespace SushiBarFileImplement.Models
{
    public class Client
    {
        /// <summary>
        /// Клиент, создающий заказы
        /// </summary>
        public int Id { get; set; }
        public string ClientFLM { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
