using System;
using System.Collections.Generic;
using System.Linq;
using TMS_DotNet_Group_2_Kunina.Homework8.Data.Models.Enums;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Data.Models
{
    public class Customer
    {
        private int _customerID;
        private decimal _cash;
        private List<Product> _cart;
        List<Product> productsList = new();

        public Customer(Dictionary<Products, Product> productDictionary, int customerID)
        {
            _customerID = customerID;
            Random random = new Random();
            _cash = random.Next(10, 300);
            CreatProductList(productDictionary);
            BuyProducts();
        }

        public int CustomerID => _customerID;

        public decimal Cash => _cash;

        public List<Product> Cart => _cart;

        private void CreatProductList(Dictionary<Products, Product> productDictionary)
        {
            Random random = new Random();
            int numberProductsNeeded = random.Next(1, 10);
            int numberProductsInListing = Enum.GetNames(typeof(Products)).Length;

            for (int i = 0; i < numberProductsNeeded; i++)
            {
                int produсtIndex = random.Next(0, numberProductsInListing - 1);
                productsList.Add(productDictionary[(Products)produсtIndex]);
            }
        }

        public void BuyProducts()
        {
            var sortedProductList = productsList.OrderBy(sort => sort.Priority);
            decimal costProducts = 0.0M;

            foreach (var product in sortedProductList)
            {
                if (costProducts + product.Price <= _cash)
                {
                    _cart.Add(product);
                    costProducts += product.Price;
                }
            }
        }
    }
}