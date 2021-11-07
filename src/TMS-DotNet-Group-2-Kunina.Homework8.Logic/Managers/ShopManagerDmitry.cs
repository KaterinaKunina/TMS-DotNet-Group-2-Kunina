using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Models;
using TMS_DotNet_Group_2_Kunina.Homework8.Data.Enums;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Interfaces;
using System.Linq;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Managers
{
    public class ShopManagerDmitry<Cashbox, Customer>
        where Cashbox : ICashbox, new()
        where Customer : ICustomer, new()
    {
        public static Dictionary<Products, Product> products = new Dictionary<Products, Product>();
        private List<Customer> customers = new List<Customer>();
        private List<Cashbox> cashboxes = new List<Cashbox>();

        public ShopManagerDmitry()
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

        public void Run(int numberCustomers, int numberCashboxes)
        {
            for (int i = 0; i < numberCashboxes; i++)
            {
                Random random = new Random();
                cashboxes.Add(new Cashbox()
                {
                    CashBoxIndex = i,
                    IsWorking = random.Next(0, 10) > 2
                });

                if (cashboxes[i].IsWorking)
                {
                    Console.WriteLine($"Cashbox {i} is working");
                }
                else
                {
                    Console.WriteLine($"Cashbox {i} is not working");
                }
            }

            CreateTasks(cashboxes, numberCashboxes, out Task[] cashboxTasks);

            for (int i = 0; i < numberCustomers; i++)
            {
                Random random = new Random();
                customers.Add(new Customer()
                {
                    CustomerID = i,
                    Cash = random.Next(50, 300),
                    DiscountCard = random.Next(1, 5)
                });

                Console.WriteLine();
                Console.WriteLine($"Customer {customers[i].CustomerID} has {customers[i].Cash} money");
                customers[i].CreatProductList(products);
            }

            CreateTasks(customers ,numberCustomers);

            foreach (var customer in customers)
            {
                Random random = new();
                int delay = random.Next(100, 1000);
                Thread.Sleep(delay);
                Cashbox leastBusyCash = cashboxes.Where(x => x.IsWorking).OrderBy(x => x.QueueLength()).First();
                leastBusyCash.TakeQueue(customer);
            }

            Task.WaitAll(cashboxTasks);
        }

        private void CreateTasks(List<Cashbox> cashboxes, int numberTasks, out Task[] tasks)
        {
            tasks = new Task[numberTasks];
            int taskIndex = 0;

            foreach (Cashbox cashbox in cashboxes)
            {
                tasks[taskIndex] = Task.Factory.StartNew(() => cashbox.GetMoney());
                taskIndex++;
            }
        }

        private void CreateTasks(List<Customer> customers, int numberTasks)
        {
            Task[] tasks = new Task[numberTasks];
            int taskIndex = 0;

            Console.WriteLine();

            foreach (Customer customer in customers)
            {
                tasks[taskIndex] = Task.Factory.StartNew(() => customer.BuyProducts());
                taskIndex++;
            }
        }
    }
}

