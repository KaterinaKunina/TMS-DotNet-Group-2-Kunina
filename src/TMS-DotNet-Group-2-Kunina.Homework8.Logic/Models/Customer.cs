using System;
using System.Collections.Generic;
using System.Linq;
using TMS_DotNet_Group_2_Kunina.Homework8.Data.Enums;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Interfaces;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Models
{
    public class Customer : ICustomer
    {
        private List<Product> _cart = new();
        private List<Product> productsList = new();

        public int CustomerID { get; set; }

        public decimal Cash { get; set; }

        public List<Product> Cart { get { return _cart; } set { } }

        public void CreatProductList(Dictionary<Products, Product> productDictionary)
        {
            Random random = new Random();
            int numberProductsNeeded = random.Next(1, 10);
            int numberProductsInListing = Enum.GetNames(typeof(Products)).Length;

            Console.WriteLine(new String('=', 50));

            for (int i = 0; i < numberProductsNeeded; i++)
            {
                int produсtIndex = random.Next(0, numberProductsInListing - 1);
                productsList.Add(productDictionary[(Products)produсtIndex]);
                Console.WriteLine($"Add a {productDictionary[(Products)produсtIndex].Name} to the list of required - for cutomer {CustomerID}");
            }

            Console.WriteLine(new String('=', 50));
        }

        public void BuyProducts()
        {
            var sortedProductList = productsList.OrderBy(sort => sort.Priority);
            decimal costProducts = default;

            foreach (var product in sortedProductList)
            {
                if (costProducts + product.Price <= Cash)
                {
                    Console.WriteLine($"Customer {CustomerID}. Buy product - {product.Name}, {product.Price}, {product.Priority}");
                    _cart.Add(product);
                    costProducts += product.Price;
                }
            }
        }
    }
}