using SushiBarContracts.BindingModels;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.StoragesContracts;
using SushiBarContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace SushiBarBusinessLogic.BusinessLogic
{
    public class StorageFacilityLogic : IStorageFacilityLogic
    {
        private readonly IStorageFacilityStorage _storageFacilityStorage;
        private readonly IIngredientStorage _ingredientStorage;
        public StorageFacilityLogic(IStorageFacilityStorage storageFacilityStorage, IIngredientStorage ingredientStorage)
        {
            _storageFacilityStorage = storageFacilityStorage;
            _ingredientStorage = ingredientStorage;
        }
        public List<StorageFacilityViewModel> Read(StorageFacilityBindingModel model)
        {
            if (model == null)
            {
                return _storageFacilityStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StorageFacilityViewModel> { _storageFacilityStorage.GetElement(model) };
            }
            return _storageFacilityStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(StorageFacilityBindingModel model)
        {
            var element = _storageFacilityStorage.GetElement(new StorageFacilityBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _storageFacilityStorage.Update(model);
            }
            else
            {
                _storageFacilityStorage.Insert(model);
            }
        }
        public void Delete(StorageFacilityBindingModel model)
        {
            var element = _storageFacilityStorage.GetElement(new StorageFacilityBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Cклад не найден");
            }
            _storageFacilityStorage.Delete(model);
        }
        public void AddIngrediend(AddIngredientBindingModel model)
        {
            var storefacility = _storageFacilityStorage.GetElement(new StorageFacilityBindingModel
            {
                Id = model.StorageFacilityId
            });

            var ingredient = _ingredientStorage.GetElement(new IngredientBindingModel
            {
                Id = model.IngredientId
            });

            if (storefacility == null)
            {
                throw new Exception("Склад не найден");
            }

            if (ingredient == null)
            {
                throw new Exception("Ингредиент не найден");
            }

            Dictionary<int, (string, int)> storagefacilityingredients = storefacility.StorageFacilityIngredients;

            if (storagefacilityingredients.ContainsKey(model.IngredientId))
            {
                storagefacilityingredients[model.IngredientId] = (storagefacilityingredients[model.IngredientId].Item1,
                    storagefacilityingredients[model.IngredientId].Item2 + model.Count);
            }
            else
            {
                storagefacilityingredients.Add(model.IngredientId, (ingredient.IngredientName, model.Count));
            }

            _storageFacilityStorage.Update(new StorageFacilityBindingModel
            {
                Id = storefacility.Id,
                Name = storefacility.Name,
                OwnerFLM = storefacility.OwnerFLM,
                DateCreate = storefacility.DateCreate,
                StorageFacilityIngredients = storagefacilityingredients
            });
        }
    }
}
