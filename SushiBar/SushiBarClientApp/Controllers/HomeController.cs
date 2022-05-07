using SushiBarContracts.ViewModels;
using SushiBarContracts.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SushiBarClientApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SushiBarClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}"));
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Client);
        }
        [HttpPost]
        public void Privacy(string login, string password, string flm)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password)
            && !string.IsNullOrEmpty(flm))
            {
                APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
                {
                    Id = Program.Client.Id,
                    ClientFLM = flm,
                    Email = login,
                    Password = password
                });
                Program.Client.ClientFLM = flm;
                Program.Client.Email = login;
                Program.Client.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
                if (Program.Client == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public void Register(string login, string password, string flm)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password)
            && !string.IsNullOrEmpty(flm))
            {
                APIClient.PostRequest("api/client/register", new ClientBindingModel
                {
                    ClientFLM = flm,
                    Email = login,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Dishes = APIClient.GetRequest<List<DishViewModel>>("api/main/getdishlist");
            return View();
        }
        [HttpPost]
        public void Create(int dish, int count, decimal sum)
        {
            if (count == 0 || sum == 0)
            {
                return;
            }
            APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
            {
                ClientId = Program.Client.Id,
                DishId = dish,
                Count = count,
                Sum = sum,
            });
            Response.Redirect("Index");
        }
        [HttpPost]
        public decimal Calc(decimal count, int dish)
        {
            DishViewModel prod = APIClient.GetRequest<DishViewModel>($"api/main/getdish?dishId={dish}");
            return count * prod.Price;
        }

        public IActionResult Mails()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<MessageInfoViewModel>>
                ($"api/main/GetMessage?clientId={Program.Client.Id}"));
        }
    }
}
