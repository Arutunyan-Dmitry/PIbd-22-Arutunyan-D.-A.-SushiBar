using SushiBarContracts.BindingModels;
using SushiBarContracts.StoragesContracts;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.ViewModels;
using System.Collections.Generic;


namespace SushiBarBusinessLogic.BusinessLogic
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly IMessageInfoStorage _messageInfoStorage;
        public MessageInfoLogic(IMessageInfoStorage messageInfoStorage)
        {
            _messageInfoStorage = messageInfoStorage;
        }
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return _messageInfoStorage.GetFullList();
            }
            return _messageInfoStorage.GetFilteredList(model);
        }
        public void Create(MessageInfoBindingModel model)
        {
            _messageInfoStorage.Insert(model);
        }
        public void Update(MessageInfoBindingModel model)
        {
            _messageInfoStorage.Update(model);
        }
    }
}
