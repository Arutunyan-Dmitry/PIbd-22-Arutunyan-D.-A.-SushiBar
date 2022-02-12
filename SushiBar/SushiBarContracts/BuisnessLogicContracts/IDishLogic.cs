using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using System.Collections.Generic;

namespace SushiBarContracts.BuisnessLogicContracts
{
    public interface IDishLogic
    {
        List<DishViewModel> Read(DishBindingModel model);
        void CreateOrUpdate(DishBindingModel model);
        void Delete(DishBindingModel model);
    }
}
