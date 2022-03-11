using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarContracts.StoragesContracts
{
    public interface IStorageFacilityStorage
    {
        List<StorageFacilityViewModel> GetFullList();
        List<StorageFacilityViewModel> GetFilteredList(StorageFacilityBindingModel model);
        StorageFacilityViewModel GetElement(StorageFacilityBindingModel model);
        void Insert(StorageFacilityBindingModel model);
        void Update(StorageFacilityBindingModel model);
        void Delete(StorageFacilityBindingModel model);
        bool TakeIngredientFromStore(Dictionary<int, (string, int)> ingredients, int dishNumb);
    }
}
