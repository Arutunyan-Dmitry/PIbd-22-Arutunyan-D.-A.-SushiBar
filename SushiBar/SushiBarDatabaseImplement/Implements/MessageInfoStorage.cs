using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using SushiBarDatabaseImplement.Models;
using SushiBarContracts.StoragesContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SushiBarDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new SushiBarDatabase();
            return context.MessageInfos
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
            using var context = new SushiBarDatabase();
            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue)
            {
                return context.MessageInfos.Skip((int)model.ToSkip).Take((int)model.ToTake)
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
            return context.MessageInfos
            .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
            (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date) || 
            (model.MessageId != null && rec.MessageId.Equals(model.MessageId)))
            .Skip(model.ToSkip ?? 0)
            .Take(model.ToTake ?? context.MessageInfos.Count())
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
            using var context = new SushiBarDatabase();
            MessageInfo element = context.MessageInfos.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element != null)
            {
                return;
            }
            context.MessageInfos.Add(new MessageInfo
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
            context.SaveChanges();
        }

        public void Update(MessageInfoBindingModel model)
        {
            using var context = new SushiBarDatabase();
            var element = context.MessageInfos.FirstOrDefault(rec => rec.MessageId == model.MessageId);
            if (element == null)
            {
                throw new Exception("Письмо не найдено");
            }
            element.IsRead = model.IsRead;
            element.Request = model.Request;
            context.SaveChanges();
        }
    }
}
