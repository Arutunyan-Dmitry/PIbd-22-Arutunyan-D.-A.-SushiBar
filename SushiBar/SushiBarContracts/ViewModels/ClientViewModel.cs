using SushiBarContracts.Attributes;
using System;
using System.Runtime.Serialization;

namespace SushiBarContracts.ViewModels
{
    /// <summary>
    /// Клиент суши бара
    /// </summary>
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Column(title: "ФИО", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFLM { get; set; }

        [Column(title: "Почта", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Email { get; set; }

        [Column(title: "Пароль", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Password { get; set; }
    }
}
