using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Interfaces;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Models
{
    public class Cashbox : ICashbox
    {
        public Queue<ICustomer> customers = new();
        private decimal totalSum;

        public int CashBoxIndex { get; set; }

        public int CasherDelayTime { get; set; }

        public bool IsWorking { get; set; }

        public int QueueLength()
        {
            return customers.Count();
        }

        public void TakeQueue(ICustomer customer)
        {
            customers.Enqueue(customer);
            Console.WriteLine($"\nA customer {customer.CustomerID} took line in Cashbox {CashBoxIndex}."
                + $" Line lenght is  {customers.Count}");
        }

        public void GetMoney()
        {
            Random random = new();
            CasherDelayTime = random.Next(1000, 3000);

            while (IsWorking)
            {
                if (customers.Count > 0)
                {
                    Thread.Sleep(CasherDelayTime);
                    ICustomer customer = customers.Dequeue();
                    var products = customer.Cart;

                    Console.WriteLine("\n");
                    Console.WriteLine(new string('=', 35));
                    Console.WriteLine($"Cashbox {CashBoxIndex}.The customer's {customer.CustomerID} check:");
                    Console.WriteLine(new string('-', 35));

                    foreach (var product in products)
                    {
                        totalSum += product.Price;
                        Console.WriteLine($"{product.Name}.......................{product.Price}");
                    }

                    Console.WriteLine(new string('-', 35));
                    Console.WriteLine($"Total sum:............... {totalSum}");
                    Console.WriteLine(new string('=', 35));
                    Console.WriteLine($"\nCustomers in the queue in cashbox - {CashBoxIndex}: {customers.Count}");
                }
            }
        }

    }
}

