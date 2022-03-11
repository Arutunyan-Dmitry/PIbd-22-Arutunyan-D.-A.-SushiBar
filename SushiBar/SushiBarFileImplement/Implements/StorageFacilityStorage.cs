using System;
using System.Collections.Generic;
using System.Linq;
using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using SushiBarFileImplement.Models;
using SushiBarContracts.StoragesContracts;

namespace SushiBarFileImplement.Implements
{
    public class StorageFacilityStorage : IStorageFacilityStorage
    {
        private readonly FileDataListSingleton source;

        public StorageFacilityStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<StorageFacilityViewModel> GetFullList()
        {
            return source.StorageFacilities.Select(CreateModel).ToList();
        }

        public List<StorageFacilityViewModel> GetFilteredList(StorageFacilityBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.StorageFacilities
                .Where(xStorageFacility => xStorageFacility.Name.Contains(model.Name))
                .Select(CreateModel)
                .ToList();
        }

        public StorageFacilityViewModel GetElement(StorageFacilityBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var storageFacility = source.StorageFacilities
                .FirstOrDefault(xStorageFacility => xStorageFacility.Name == model.Name
                || xStorageFacility.Id == model.Id);
            return storageFacility != null ? CreateModel(storageFacility) : null;
        }

        public void Insert(StorageFacilityBindingModel model)
        {
            int maxId = source.StorageFacilities.Count > 0 
                ? source.StorageFacilities.Max(xStorageFacility => xStorageFacility.Id) : 0;
            var storageFacility = new StorageFacility 
            { 
                Id = maxId + 1, 
                StorageFacilityIngredients = new Dictionary<int, int>(), 
                DateCreate = DateTime.Now 
            };
            source.StorageFacilities.Add(CreateModel(model, storageFacility));
        }

        public void Update(StorageFacilityBindingModel model)
        {
            var storageFacility = source.StorageFacilities
                .FirstOrDefault(xStorageFacility => xStorageFacility.Id == model.Id);
            if (storageFacility == null)
            {
                throw new Exception("Склад не найден");
            }
            CreateModel(model, storageFacility);
        }

        public void Delete(StorageFacilityBindingModel model)
        {
            var storageFacility = source.StorageFacilities
                .FirstOrDefault(xStoreHouse => xStoreHouse.Id == model.Id);
            if (storageFacility != null)
            {
                source.StorageFacilities.Remove(storageFacility);
            }
            else
            {
                throw new Exception("Склад не найден");
            }
        }

        public bool TakeIngredientFromStore(Dictionary<int, (string, int)> ingredients, int dishNumb)
        {
            foreach (var storageFacilityIngredient in ingredients)
            {
                int count = source.StorageFacilities
                    .Where(ingredient => ingredient.StorageFacilityIngredients
                    .ContainsKey(storageFacilityIngredient.Key))
                    .Sum(ingredient => ingredient.StorageFacilityIngredients[storageFacilityIngredient
                    .Key]);
                if (count < storageFacilityIngredient.Value.Item2 * dishNumb)
                {
                    return false;
                }
            }

            foreach (var storageFacilityIngredient in ingredients)
            {
                int count = storageFacilityIngredient.Value.Item2 * dishNumb;
                IEnumerable<StorageFacility> storageFacilities = source.StorageFacilities
                    .Where(ingredient => ingredient.StorageFacilityIngredients
                    .ContainsKey(storageFacilityIngredient.Key));

                foreach (var storageFacility in storageFacilities)
                {
                    if (storageFacility
                        .StorageFacilityIngredients[storageFacilityIngredient.Key] <= count)
                    {
                        count -= storageFacility.StorageFacilityIngredients[storageFacilityIngredient.Key];
                        storageFacility.StorageFacilityIngredients.Remove(storageFacilityIngredient.Key);
                    }
                    else
                    {
                        storageFacility.StorageFacilityIngredients[storageFacilityIngredient.Key] -= count;
                        count = 0;
                    }

                    if (count == 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }

        private StorageFacility CreateModel(StorageFacilityBindingModel model, StorageFacility storageFacility)
        {
            storageFacility.Name = model.Name;
            storageFacility.OwnerFLM = model.OwnerFLM;

            foreach (var key in storageFacility.StorageFacilityIngredients.Keys.ToList())
            {
                if (!model.StorageFacilityIngredients.ContainsKey(key))
                {
                    storageFacility.StorageFacilityIngredients.Remove(key);
                }
            }

            foreach (var material in model.StorageFacilityIngredients)
            {
                if (storageFacility.StorageFacilityIngredients.ContainsKey(material.Key))
                {
                    storageFacility.StorageFacilityIngredients[material.Key] =
                        model.StorageFacilityIngredients[material.Key].Item2;
                }
                else
                {
                    storageFacility.StorageFacilityIngredients
                        .Add(material.Key, model.StorageFacilityIngredients[material.Key].Item2);
                }
            }
            return storageFacility;
        }

        private StorageFacilityViewModel CreateModel(StorageFacility storageFacility)
        {
            Dictionary<int, (string, int)> storageFacilityIngredients = new Dictionary<int, (string, int)>();

            foreach (var storageFacilityIngredient in storageFacility.StorageFacilityIngredients)
            {
                string IngredientName = string.Empty;
                foreach (var ingredient in source.Ingredients)
                {
                    if (storageFacilityIngredient.Key == ingredient.Id)
                    {
                        IngredientName = ingredient.IngredientName;
                        break;
                    }
                }
                storageFacilityIngredients.Add(storageFacilityIngredient.Key, (IngredientName, storageFacilityIngredient.Value));
            }

            return new StorageFacilityViewModel
            {
                Id = storageFacility.Id,
                Name = storageFacility.Name,
                OwnerFLM = storageFacility.OwnerFLM,
                DateCreate = storageFacility.DateCreate,
                StorageFacilityIngredients = storageFacilityIngredients
            };
        }
    }
}
