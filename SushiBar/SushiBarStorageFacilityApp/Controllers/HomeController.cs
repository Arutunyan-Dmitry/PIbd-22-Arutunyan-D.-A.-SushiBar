using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using SushiBarStorageFacilityApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SushiBarStorageFacilityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Enter");
            }

            return View(APIClient.GetRequest<List<StorageFacilityViewModel>>($"api/StorageFacility/GetStorageFacilityList"));
        }

        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                Program.Authorization = password == _configuration["Password"];

                if (!Program.Authorization)
                {
                    throw new Exception("Неверный пароль");
                }

                Response.Redirect("Index");
                return;
            }

            throw new Exception("Введите пароль");
        }

        public IActionResult CreateOrUpdate(int? id)
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Enter");
            }
            if (id == null)
            {
                return View();
            }
            var storageFacility = APIClient.GetRequest<List<StorageFacilityViewModel>>($"api/StorageFacility/GetStorageFacilityList")
                .FirstOrDefault(rec => rec.Id == id);
            if (storageFacility == null)
            {
                return View();
            }
            return View(storageFacility);
        }
        [HttpPost]
        public void Create([Bind("Name, OwnerFLM")] StorageFacilityBindingModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.OwnerFLM))
            {
                return;
            }
            model.StorageFacilityIngredients = new Dictionary<int, (string, int)>();
            APIClient.PostRequest("api/StorageFacility/Create", model);
            Response.Redirect("Index");
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,Name,OwnerFLM")] StorageFacilityBindingModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            var storageFacility = APIClient.GetRequest<List<StorageFacilityViewModel>>($"api/StorageFacility/GetStorageFacilityList")
                 .FirstOrDefault(rec => rec.Id == id);
            model.StorageFacilityIngredients = storageFacility.StorageFacilityIngredients;

            APIClient.PostRequest("api/StorageFacility/Update", model);
            return Redirect("~/Home/Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageFacility = APIClient.GetRequest<List<StorageFacilityViewModel>>($"api/StorageFacility/GetStorageFacilityList")
                .FirstOrDefault(rec => rec.Id == id);
            if (storageFacility == null)
            {
                return NotFound();
            }

            return View(storageFacility);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            APIClient.PostRequest("api/StorageFacility/Delete", new StorageFacilityBindingModel { Id = id });
            return Redirect("~/Home/Index");
        }

        public IActionResult AddIngredient()
        {
            if (!Program.Authorization)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.StorageFacilities = APIClient.GetRequest<List<StorageFacilityViewModel>>($"api/StorageFacility/GetStorageFacilityList");
            ViewBag.Ingredients = APIClient.GetRequest<List<IngredientViewModel>>($"api/StorageFacility/GetIngredientList");

            return View();
        }

        [HttpPost]
        public IActionResult AddIngredient([Bind("StorageFacilityId, IngredientId, Count")] AddIngredientBindingModel model)
        {
            if (model.StorageFacilityId == 0 || model.IngredientId == 0 || model.Count <= 0)
            {
                return NotFound();
            }

            var storageFacility = APIClient.GetRequest<List<StorageFacilityViewModel>>($"api/StorageFacility/GetStorageFacilityList")
                .FirstOrDefault(rec => rec.Id == model.StorageFacilityId);
            if (storageFacility == null)
            {
                return NotFound();
            }

            var ingredient = APIClient.GetRequest<List<StorageFacilityViewModel>>($"api/StorageFacility/GetIngredientList")
                .FirstOrDefault(rec => rec.Id == model.IngredientId);
            if (ingredient == null)
            {
                return NotFound();
            }

            APIClient.PostRequest($"api/StorageFacility/AddIngredient", model);
            return Redirect("~/Home/AddIngredient"); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
