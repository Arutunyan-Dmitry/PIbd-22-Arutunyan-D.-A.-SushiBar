using System;
using System.Collections.Generic;
using System.Linq;
using SushiBarContracts.BindingModels;
using SushiBarContracts.ViewModels;
using SushiBarListImplement.Models;
using SushiBarContracts.StoragesContracts;

namespace SushiBarListImplement.Implements
{
    public class StorageFacilityStorage : IStorageFacilityStorage
    {
        private readonly DataListSingleton source;

        public StorageFacilityStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        
        public List<StorageFacilityViewModel> GetFullList()
        {
            var result = new List<StorageFacilityViewModel>();
            foreach (var storageFacility in source.StorageFacilities)
            {
                result.Add(CreateModel(storageFacility));
            }
            return result;
        }
        public List<StorageFacilityViewModel> GetFilteredList(StorageFacilityBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new List<StorageFacilityViewModel>();
            foreach (var storageFacility in source.StorageFacilities)
            {
                if (storageFacility.Name.Contains(model.Name))
                {
                    result.Add(CreateModel(storageFacility));
                }
            }
            return result;
        }
        public StorageFacilityViewModel GetElement(StorageFacilityBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (var storageFacility in source.StorageFacilities)
            {
                if (storageFacility.Id == model.Id || storageFacility.Name == model.Name)
                {
                    return CreateModel(storageFacility);
                }
            }
            return null;
        }

        public void Insert(StorageFacilityBindingModel model)
        {
            var tempStorageFacility = new StorageFacility
            {
                Id = 1,
                StorageFacilityIngredients = new Dictionary<int, int>(),
                DateCreate = DateTime.Now
            };
            foreach (var storageFacility in source.StorageFacilities)
            {              
                if (storageFacility.Id >= tempStorageFacility.Id)
                {
                    tempStorageFacility.Id = storageFacility.Id + 1;
                }
            }
            source.StorageFacilities.Add(CreateModel(model, tempStorageFacility));
        }
        public void Update(StorageFacilityBindingModel model)
        {
            StorageFacility tempStorageFacility = null;
            foreach (var storageFacility in source.StorageFacilities)
            {
                if (storageFacility.Id == model.Id)
                {
                    tempStorageFacility = storageFacility;
                }
            }

            if (tempStorageFacility == null)
            {
                throw new Exception("Склад не найден");
            }

            CreateModel(model, tempStorageFacility);
        }
        public void Delete(StorageFacilityBindingModel model)
        {
            for (int i = 0; i < source.StorageFacilities.Count; ++i)
            {
                if (source.StorageFacilities[i].Id == model.Id)
                {
                    source.StorageFacilities.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Склад не найден");
        }

        private StorageFacility CreateModel(StorageFacilityBindingModel model, StorageFacility storageFacility)
        {
            storageFacility.Name = model.Name;
            storageFacility.OwnerFLM = model.OwnerFLM;

            foreach (int key in storageFacility.StorageFacilityIngredients.Keys.ToList())
            {
                if (!model.StorageFacilityIngredients.ContainsKey(key))
                {
                    storageFacility.StorageFacilityIngredients.Remove(key);
                }
            }

            foreach (KeyValuePair<int, (string, int)> ingredient in model.StorageFacilityIngredients)
            {
                if (storageFacility.StorageFacilityIngredients.ContainsKey(ingredient.Key))
                {
                    storageFacility.StorageFacilityIngredients[ingredient.Key] = model.StorageFacilityIngredients[ingredient.Key].Item2;
                }
                else
                {
                    storageFacility.StorageFacilityIngredients.Add(ingredient.Key, model.StorageFacilityIngredients[ingredient.Key].Item2);
                }
            }

            return storageFacility;
        }
        private StorageFacilityViewModel CreateModel(StorageFacility storageFacility)
        {
            Dictionary<int, (string, int)> storageFacilityIngredients = new Dictionary<int, (string, int)>();

            foreach (KeyValuePair<int, int> storageFacilityIngredient in storageFacility.StorageFacilityIngredients)
            {
                string ingredientName = string.Empty;
                foreach (var ingredient in source.Ingredients)
                {
                    if (storageFacilityIngredient.Key == ingredient.Id)
                    {
                        ingredientName = ingredient.IngredientName;
                        break;
                    }
                }
                storageFacilityIngredients.Add(storageFacilityIngredient.Key, (ingredientName, storageFacilityIngredient.Value));
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
