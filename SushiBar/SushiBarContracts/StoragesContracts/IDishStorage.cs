using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarContracts.StoragesContracts
{
    public interface IDishStorage
    {
        List<DishViewModel> GetFullList();
        List<DishViewModel> GetFilteredList(DishBindingModel model);
        DishViewModel GetElement(DishBindingModel model);
        void Insert(DishBindingModel model);
        void Update(DishBindingModel model);
        void Delete(DishBindingModel model);
    }
}
