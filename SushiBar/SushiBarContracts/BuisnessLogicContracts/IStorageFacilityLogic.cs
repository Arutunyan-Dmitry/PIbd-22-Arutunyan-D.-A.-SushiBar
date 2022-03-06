using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarContracts.BuisnessLogicContracts
{
    public interface IStorageFacilityLogic
    {
        List<StorageFacilityViewModel> Read(StorageFacilityBindingModel model);
        void CreateOrUpdate(StorageFacilityBindingModel model);
        void Delete(StorageFacilityBindingModel model);
        void AddIngrediend(AddIngredientBindingModel model);
    }
}
