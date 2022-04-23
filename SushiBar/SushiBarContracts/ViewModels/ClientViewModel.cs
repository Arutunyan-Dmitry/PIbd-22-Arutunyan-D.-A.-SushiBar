using System.ComponentModel;

namespace SushiBarContracts.ViewModels
{
    /// <summary>
    /// Клиент суши бара
    /// </summary>
    public class ClientViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string ClientFLM { get; set; }

        [DisplayName("Почта")]
        public string Email { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
