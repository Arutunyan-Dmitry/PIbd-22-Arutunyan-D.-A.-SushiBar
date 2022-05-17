using SushiBarContracts.BindingModels;
using SushiBarContracts.StoragesContracts;
using SushiBarContracts.ViewModels;
using SushiBarListImplement.Models;
using System;
using System.Collections.Generic;

namespace SushiBarListImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton source;
        public MessageInfoStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<MessageInfoViewModel> GetFullList()
        {
            var result = new List<MessageInfoViewModel>();
            foreach (var mi in source.MessageInfos)
            {
                result.Add(new MessageInfoViewModel
                {
                    MessageId = mi.MessageId,
                    SenderName = mi.SenderName,
                    DateDelivery = mi.DateDelivery,
                    Subject = mi.Subject,
                    Body = mi.Body,
                    IsRead = mi.IsRead,
                    Request = mi.Request
                });
            }
            return result;
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            int toSkip = model.ToSkip ?? 0;
            int toTake = model.ToTake ?? source.MessageInfos.Count;

            var result = new List<MessageInfoViewModel>();

            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue)
            {
                foreach (var mi in source.MessageInfos)
                {
                    if (toSkip > 0) { toSkip--; continue; }
                    if (toTake > 0)
                    {
                        result.Add(new MessageInfoViewModel
                        {
                            MessageId = mi.MessageId,
                            SenderName = mi.SenderName,
                            DateDelivery = mi.DateDelivery,
                            Subject = mi.Subject,
                            Body = mi.Body,
                            IsRead = mi.IsRead,
                            Request = mi.Request
                        });
                        toTake--;
                    }
                }
                return result;
            }
            foreach (var mi in source.MessageInfos)
            {
                if ((model.ClientId.HasValue && mi.ClientId == model.ClientId) ||
                    (!model.ClientId.HasValue && mi.DateDelivery.Date == model.DateDelivery.Date))
                {
                    if (toSkip > 0) { toSkip--; continue; }
                    if (toTake > 0)
                    {
                        result.Add(new MessageInfoViewModel
                        {
                            MessageId = mi.MessageId,
                            SenderName = mi.SenderName,
                            DateDelivery = mi.DateDelivery,
                            Subject = mi.Subject,
                            Body = mi.Body,
                            IsRead = mi.IsRead,
                            Request = mi.Request
                        });
                        toTake--;
                    }
                }
            }
            return result;
        }
        public void Insert(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            source.MessageInfos.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = model.ClientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body,
                IsRead = model.IsRead,
                Request = model.Request
            });
        }
        public void Update(MessageInfoBindingModel model)
        {
            MessageInfo tempMI = null;
            foreach (var mi in source.MessageInfos)
            {
                if (mi.MessageId == model.MessageId)
                {
                    tempMI = mi;
                }
            }
            if (tempMI == null)
            {
                throw new Exception("Элемент не найден");
            }
            tempMI.MessageId = model.MessageId;
            tempMI.ClientId = model.ClientId;
            tempMI.SenderName = model.FromMailAddress;
            tempMI.DateDelivery = model.DateDelivery;
            tempMI.Subject = model.Subject;
            tempMI.Body = model.Body;
            tempMI.IsRead = model.IsRead;
            tempMI.Request = model.Request;
        }
    }
}
