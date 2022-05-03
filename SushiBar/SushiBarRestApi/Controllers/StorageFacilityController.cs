using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using SushiBarContracts.BuisnessLogicContracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SushiBarRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorageFacilityController : ControllerBase
    {
        private readonly IStorageFacilityLogic _storageFacilityLogic;
        private readonly IIngredientLogic _ingredientLogic;
        public StorageFacilityController(IStorageFacilityLogic storageFacilityLogic, IIngredientLogic ingredientLogic)
        {
            _ingredientLogic = ingredientLogic;
            _storageFacilityLogic = storageFacilityLogic;   
        }
        [HttpGet]
        public List<IngredientViewModel> GetIngredientList() => _ingredientLogic.Read(null);
        [HttpGet]
        public List<StorageFacilityViewModel> GetStorageFacilityList() => _storageFacilityLogic.Read(null);
        [HttpPost]
        public void Create(StorageFacilityBindingModel model) => _storageFacilityLogic.CreateOrUpdate(model);
        [HttpPost]
        public void Update(StorageFacilityBindingModel model) => _storageFacilityLogic.CreateOrUpdate(model);
        [HttpPost]
        public void Delete(StorageFacilityBindingModel model) => _storageFacilityLogic.Delete(model);
        [HttpPost]
        public void AddIngredient(AddIngredientBindingModel model) => _storageFacilityLogic.AddIngrediend(model);
    }
}
