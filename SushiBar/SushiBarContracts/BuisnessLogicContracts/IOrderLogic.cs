using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarContracts.BuisnessLogicContracts
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrder(CreateOrderBindingModel model);
        void TakeOrderPreparing(ChangeStatusBindingModel model);
        void FinishOrder(ChangeStatusBindingModel model);
        void DeliveryOrder(ChangeStatusBindingModel model);
    }
}
