using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using SushiBarContracts.BuisnessLogicContracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace SushiBarRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IDishLogic _dish;
        private readonly IMessageInfoLogic _messageInfo;
        private readonly int mailsOnPage = 2;
        private int NumOfPages;
        public MainController(IOrderLogic order, IDishLogic dish, IMessageInfoLogic messageInfo)
        {
            _messageInfo = messageInfo;
            _order = order;
            _dish = dish;
            if (mailsOnPage < 1) { mailsOnPage = 5; }
        }
        [HttpGet]
        public List<DishViewModel> GetDishList() => _dish.Read(null)?.ToList();
        [HttpGet]
        public DishViewModel GetDish(int dishId) => _dish.Read(new DishBindingModel
        { Id = dishId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
        [HttpGet]
        public (List<MessageInfoViewModel>, int) GetMessage(int clientId, int page)
        {
            var fullList = _messageInfo.Read(null);
            NumOfPages = fullList.Count / mailsOnPage;
            if (fullList.Count % mailsOnPage != 0) { NumOfPages++; }

            var list = _messageInfo.Read(new MessageInfoBindingModel { ClientId = clientId, ToSkip = (page - 1) * mailsOnPage, ToTake = mailsOnPage }).ToList();
            return (list.Take(mailsOnPage).ToList(), NumOfPages);
        }
    }
}
