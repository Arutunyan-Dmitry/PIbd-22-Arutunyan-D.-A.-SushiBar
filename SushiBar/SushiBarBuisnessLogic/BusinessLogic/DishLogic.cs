using SushiBarContracts.BindingModels;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.StoragesContracts;
using SushiBarContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.BusinessLogic
{
    public class DishLogic : IDishLogic
    {
        private readonly IDishStorage _dishStorage;
        public DishLogic(IDishStorage dishStorage)
        {
            _dishStorage = dishStorage;
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            if (model == null)
            {
                return _dishStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DishViewModel> { _dishStorage.GetElement(model) };
            }
            return _dishStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(DishBindingModel model)
        {
            var element = _dishStorage.GetElement(new DishBindingModel
            {
                DishName = model.DishName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть блюдо с таким названием");
            }
            if (model.Id.HasValue)
            {
                _dishStorage.Update(model);
            }
            else
            {
                _dishStorage.Insert(model);
            }
        }
        public void Delete(DishBindingModel model)
        {
            var element = _dishStorage.GetElement(new DishBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Блюдо не найдено");
            }
            _dishStorage.Delete(model);
        }
    }
}
