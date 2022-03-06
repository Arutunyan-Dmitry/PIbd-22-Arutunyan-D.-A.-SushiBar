using SushiBarListImplement.Models;
using System.Collections.Generic;

namespace SushiBarListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Ingredient> Ingredients { get; set; }
        public List<Order> Orders { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<StorageFacility> StorageFacilities { get; set; }
        private DataListSingleton()
        {
            Ingredients = new List<Ingredient>();
            Orders = new List<Order>();
            Dishes = new List<Dish>();
            StorageFacilities = new List<StorageFacility>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }

    }
}