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

        public List<Product> Cart => _cart;

        public void CreatProductList(Dictionary<Products, Product> productDictionary)
        {
            Random random = new Random();
            int numberProductsNeeded = random.Next(1, 10);
            int numberProductsInListing = Enum.GetNames(typeof(Products)).Length;

            for (int i = 0; i < numberProductsNeeded; i++)
            {
                int produсtIndex = random.Next(0, numberProductsInListing - 1);
                productsList.Add(productDictionary[(Products)produсtIndex]);
                Console.WriteLine($"Add product to list needed - {productDictionary[(Products)produсtIndex].Name} for cutomer {CustomerID}");
            }
        }

        public void BuyProducts()
        {
            var sortedProductList = productsList.OrderBy(sort => sort.Priority);
            decimal costProducts = 0.0M;

            Console.WriteLine($"Customer cash - {Cash}");
            foreach (var product in sortedProductList)
            {
                if (costProducts + product.Price <= Cash)
                {
                    Console.WriteLine($"Buy product - {product.Name}, {product.Price}, {product.Priority}");
                    _cart.Add(product);
                    costProducts += product.Price;
                    Console.WriteLine($"Cart price - {costProducts}");
                }
                
            }
        }
    }
}