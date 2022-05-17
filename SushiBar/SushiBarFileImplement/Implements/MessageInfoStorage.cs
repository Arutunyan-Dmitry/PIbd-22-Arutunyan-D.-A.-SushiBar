using SushiBarContracts.BindingModels;
using SushiBarContracts.StoragesContracts;
using SushiBarContracts.ViewModels;
using SushiBarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SushiBarFileImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly FileDataListSingleton source;

        public MessageInfoStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<MessageInfoViewModel> GetFullList()
        {
            return source.MessageInfos
            .Select(rec => new MessageInfoViewModel
            {
                MessageId = rec.MessageId,
                SenderName = rec.SenderName,
                DateDelivery = rec.DateDelivery,
                Subject = rec.Subject,
                Body = rec.Body,
                IsRead = rec.IsRead,
                Request = rec.Request,
            })
            .ToList();
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue)
            {
                return source.MessageInfos.Skip((int)model.ToSkip).Take((int)model.ToTake)
                .Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body,
                    IsRead = rec.IsRead,
                    Request = rec.Request,
                }).ToList();
            }
            return source.MessageInfos
            .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
            (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date) ||
            (model.MessageId != null && rec.MessageId.Equals(model.MessageId)))
            .Skip(model.ToSkip ?? 0)
            .Take(model.ToTake ?? source.MessageInfos.Count())
            .Select(rec => new MessageInfoViewModel
            {
                MessageId = rec.MessageId,
                SenderName = rec.SenderName,
                DateDelivery = rec.DateDelivery,
                Subject = rec.Subject,
                Body = rec.Body,
                IsRead = rec.IsRead,
                Request = rec.Request,
            })
            .ToList();
        }
        public void Insert(MessageInfoBindingModel model)
        {
            var element = source.MessageInfos.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element != null)
            {
                throw new Exception("Уже есть письмо с таким идентификатором");
            }
            source.MessageInfos.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                IsRead = model.IsRead,
                Body = model.Body,
                Request = model.Request,
            });
        }

        public void Update(MessageInfoBindingModel model)
        {
            var element = source.MessageInfos.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element == null)
            {
                throw new Exception("Письмо не найдено");
            }
            element.IsRead = model.IsRead;
            element.Request = model.Request;
        }
    }
}
