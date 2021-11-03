using System;
using System.Linq;
using System.Collections.Generic;

namespace CashSimulator
{
    public class Product
    {
        private int id;
        private string productName;
        private double price;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private static Product[] GetAllProducts()
        {
            Product[] products =
            {
                new Product() { Id = 1, ProductName = "milk_1l_1.5%", price = 1.5 },
                new Product() { Id = 2, ProductName = "milk_1l_2.5%", price = 1.75 },
                new Product() { Id = 3, ProductName = "milk_1l_3.0%", price = 2.01 },
                new Product() { Id = 4, ProductName = "bread", price = 1.2 },
                new Product() { Id = 5, ProductName = "loaf", price = 1.5 },
                new Product() { Id = 6, ProductName = "bunWithJam", price = 0.75 },
                new Product() { Id = 7, ProductName = "bunWithCheese", price = 1.1 },
                new Product() { Id = 8, ProductName = "cheese", price = 15.99 },
                new Product() { Id = 9, ProductName = "chiken", price = 8.95 },
                new Product() { Id = 10, ProductName = "shashlik", price = 25.5 },
                new Product() { Id = 11, ProductName = "eggsC0", price = 3.5 },
                new Product() { Id = 12, ProductName = "eggsC1", price = 2.85 },
                new Product() { Id = 13, ProductName = "pork", price = 19.75 },
                new Product() { Id = 14, ProductName = "sausages", price = 8.5 },
                new Product() { Id = 15, ProductName = "kefir", price = 1.85 },
                new Product() { Id = 16, ProductName = "crisps", price = 2.85 },
                new Product() { Id = 17, ProductName = "fish", price = 12.99 },
                new Product() { Id = 18, ProductName = "pasta", price = 3.25 },
                new Product() { Id = 19, ProductName = "buckwheat", price = 1.9 },
                new Product() { Id = 20, ProductName = "oatmeal", price = 1.15 },
            };
            return products;
        }

        public static Dictionary<int, Product> Product_ToDictionary()
        {
            var result = GetAllProducts().ToDictionary(k => k.Id);
            return result;
        }
    }
}
