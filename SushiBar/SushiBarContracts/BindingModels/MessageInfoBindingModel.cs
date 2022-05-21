using System;

namespace SushiBarContracts.BindingModels
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    public class MessageInfoBindingModel
    {
        public int? ClientId { get; set; }
        public string MessageId { get; set; }
        public string FromMailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DateDelivery { get; set; }
        public bool IsRead { get; set; }
        public string Request { get; set; }
        public int? ToSkip { get; set; }
        public int? ToTake { get; set; }
    }
}
