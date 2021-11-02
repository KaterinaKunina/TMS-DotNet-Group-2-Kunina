using System;
using System.Collections.Generic;
using System.Threading;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Models;
using TMS_DotNet_Group_2_Kunina.Homework8.Data.Enums;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Interfaces;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Managers
{
    public class ShopManager<Cashbox, Customer>
        where Cashbox : ICashbox, new()
        where Customer : ICustomer, new()    
    {
        public static Dictionary<Products, Product> products = new Dictionary<Products, Product>();
        private List<Customer> customers = new List<Customer>();
        private List<Cashbox> cashboxes = new List<Cashbox>();

        public ShopManager()
        {
            products.Add(Products.cheese, new Product(Products.cheese, 65.0M, Priorities.high));
            products.Add(Products.bread, new Product(Products.bread, 30.0M, Priorities.high));
            products.Add(Products.wine, new Product(Products.wine, 150.0M, Priorities.low));
            products.Add(Products.milk, new Product(Products.milk, 50.0M, Priorities.low));
            products.Add(Products.water, new Product(Products.water, 30.0M, Priorities.high));
            products.Add(Products.butter, new Product(Products.butter, 30.0M, Priorities.medium));
            products.Add(Products.bear, new Product(Products.bear, 35.0M, Priorities.medium));
            products.Add(Products.lemon, new Product(Products.lemon, 70.0M, Priorities.low));
            products.Add(Products.orange, new Product(Products.milk, 60.0M, Priorities.medium));
            products.Add(Products.meat, new Product(Products.meat, 100.0M, Priorities.high));
            products.Add(Products.cake, new Product(Products.milk, 50.0M, Priorities.medium));
        }

        public void Run(int numberCustomers, int numberCashbox)
        {
            for (int i = 0; i < numberCashbox; i++)
            {
                Random random = new Random();
                
                cashboxes.Add(new Cashbox() {
                    CashBoxIndex = i,
                    IsWorking = random.Next(0, 5) > 2
                });
            }

            for (int i = 0; i < numberCustomers; i++)
            {
                Random random = new Random();

                customers.Add(new Customer() {
                    CustomerID = i,
                    Cash = random.Next(50, 300)
                });
                customers[i].CreatProductList(products);
            }

            foreach (Cashbox cashbox in cashboxes)
            {
                Thread cashboxThread = new Thread(cashbox.QueueLength);
                cashboxThread.Start();
            }

            foreach (Customer customer in customers)
            {
                Thread customerThread = new Thread(customer.BuyProducts);
                customerThread.Start();
            }
        }
    }
}

