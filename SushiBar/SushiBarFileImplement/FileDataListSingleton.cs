using SushiBarContracts.Enums;
using SushiBarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SushiBarFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string IngredientFileName = "Ingredient.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string DishFileName = "Dish.xml";
        private readonly string StorageFacilityFileName = "StorageFacility.xml";
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        public List<Ingredient> Ingredients { get; set; }
        public List<Order> Orders { get; set; }
        public List<Dish> Dishes { get; set; }
        public List<StorageFacility> StorageFacilities { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        private FileDataListSingleton()
        {
            Ingredients = LoadIngredients();
            Orders = LoadOrders();
            Dishes = LoadDishes();
            StorageFacilities = LoadStorageFacilities();
            Clients = LoadClients();
            Implementers = LoadImplementers();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        public static void SaveFileDataListSingleton()
        {
            instance.SaveIngredients();
            instance.SaveDishes();
            instance.SaveOrders();
            instance.SaveStorageFacilities();
            instance.SaveClients();
            instance.SaveImplementers();
        }
        private List<Ingredient> LoadIngredients()
        {
            var list = new List<Ingredient>();
            if (File.Exists(IngredientFileName))
            {
                var xDocument = XDocument.Load(IngredientFileName);
                var xElements = xDocument.Root.Elements("Ingredient").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Ingredient
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IngredientName = elem.Element("IngredientName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DishId = Convert.ToInt32(elem.Element("DishId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                        elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value)
                        ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }
        private List<Dish> LoadDishes()
        {
            var list = new List<Dish>();
            if (File.Exists(DishFileName))
            {
                var xDocument = XDocument.Load(DishFileName);
                var xElements = xDocument.Root.Elements("Dish").ToList();
                foreach (var elem in xElements)
                {
                    var dishIng = new Dictionary<int, int>();
                    foreach (var ingredient in
                    elem.Element("DishIngredients").Elements("DishIngredient").ToList())
                    {
                        dishIng.Add(Convert.ToInt32(ingredient.Element("Key").Value),
                        Convert.ToInt32(ingredient.Element("Value").Value));
                    }
                    list.Add(new Dish
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DishName = elem.Element("DishName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        DishIngredients = dishIng
                    });
                }
            }
            return list;
        }
        private List<StorageFacility> LoadStorageFacilities()
        {
            var list = new List<StorageFacility>();
            if (File.Exists(StorageFacilityFileName))
            {
                var xDocument = XDocument.Load(StorageFacilityFileName);
                var xElements = xDocument.Root.Elements("StorageFacility").ToList();
                foreach (var storagefacility in xElements)
                {
                    var storageFacilityIngredients = new Dictionary<int, int>();
                    foreach (var material in
                        storagefacility.Element("StorageFacilityIngredients")
                        .Elements("StorageFacilityIngredient").ToList())
                    {
                        storageFacilityIngredients.Add(Convert.ToInt32(material.Element("Key").Value),
                        Convert.ToInt32(material.Element("Value").Value));
                    }

                    list.Add(new StorageFacility
                    {
                        Id = Convert.ToInt32(storagefacility.Attribute("Id").Value),
                        Name = storagefacility.Element("Name").Value,
                        OwnerFLM = storagefacility.Element("OwnerFLM").Value,
                        DateCreate = Convert.ToDateTime(storagefacility.Element("DateCreate").Value),
                        StorageFacilityIngredients = storageFacilityIngredients
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                var xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFLM = elem.Element("ClientFLM").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }
        private List<Implementer> LoadImplementers() {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                var xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFLM = elem.Element("ImplementerFLM").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                    });
                }
            }
            return list;
        }

        private void SaveIngredients()
        {
            if (Ingredients != null)
            {
                var xElement = new XElement("Ingredients");
                foreach (var ingredient in Ingredients)
                {
                    xElement.Add(new XElement("Ingredient",
                    new XAttribute("Id", ingredient.Id),
                    new XElement("IngredientName", ingredient.IngredientName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(IngredientFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("DishId", order.DishId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveDishes()
        {
            if (Dishes != null)
            {
                var xElement = new XElement("Dishes");
                foreach (var dish in Dishes)
                {
                    var ingElement = new XElement("DishIngredients");
                    foreach (var ingredient in dish.DishIngredients)
                    {
                        ingElement.Add(new XElement("DishIngredient",
                        new XElement("Key", ingredient.Key),
                        new XElement("Value", ingredient.Value)));
                    }
                    xElement.Add(new XElement("Dish",
                     new XAttribute("Id", dish.Id),
                     new XElement("DishName", dish.DishName),
                     new XElement("Price", dish.Price),
                     ingElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(DishFileName);
            }
        }
        private void SaveStorageFacilities()
        {
            if (StorageFacilities != null)
            {
                var xElement = new XElement("StorageFacilities");
                foreach (var storagefacility in StorageFacilities)
                {
                    var storageFacilityIngredients = new XElement("StorageFacilityIngredients");
                    foreach (var dish in storagefacility.StorageFacilityIngredients)
                    {
                        storageFacilityIngredients.Add(new XElement("StorageFacilityIngredient",
                            new XElement("Key", dish.Key),
                            new XElement("Value", dish.Value)));
                    }
                    xElement.Add(new XElement("StorageFacility",
                        new XAttribute("Id", storagefacility.Id),
                        new XElement("Name", storagefacility.Name),
                        new XElement("OwnerFLM", storagefacility.OwnerFLM),
                        new XElement("DateCreate", storagefacility.DateCreate.ToString()),
                        storageFacilityIngredients));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(StorageFacilityFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFLM", client.ClientFLM),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }

        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFLM", implementer.ImplementerFLM),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
    }
}
