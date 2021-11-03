using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Collections;
using System.Timers;
using System.Threading.Tasks;

namespace CashSimulator
{
    class Programm
    {
        static void Main(string[] args)
        {
            // Grocery store

            Random random = new();
            const int MaxCustomersCount = 10;
            const int MaxWallet = 50;

            // Create Customers

            int customersCount = random.Next(1, MaxCustomersCount);
            Console.WriteLine("countCustomer = " + customersCount);
            Customer[] customers = new Customer[customersCount];

            // Create count of cash

            int cashCount = 0;
            bool isCorrectCashCount = false;

            while (!isCorrectCashCount)
            {
                Console.WriteLine("Input count Cash in the Shop");
                string cashCountStr = Console.ReadLine();
                try
                {
                    cashCount = (int)Convert.ToUInt32(cashCountStr);
                    if (cashCount > 0)
                    {
                        isCorrectCashCount = true;
                    }
                    else
                    {
                        Console.Write("Cannot be 0 cash in the Shop. ");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not an integer", cashCountStr);
                }
            }

            Queue<Customer>[] queueCash = new Queue<Customer>[cashCount]; // queue customers for cash

            Task[] cashTasks = new Task[cashCount];


            for (int i = 0; i < cashCount; i++)
            {
                queueCash[i] = new Queue<Customer>();
            }



            for (int i = 0; i < customersCount; i++)
            {
                Customer customer = new();
                customer.id = i;
                customer.wallet = random.Next(10, MaxWallet);
                customer.MakePurchases();

                customers[i] = customer;
                customer.ListOfProductsInBasket();
                // Customer go to cash
                queueCash[random.Next(cashCount)].Enqueue(customers[i]);

            }



            for (int i = 0; i < cashTasks.Length; i++)
            {
                cashTasks[i] = Task.Run(() =>
                {
                    int i = (int)Task.CurrentId - 1;

                    if (queueCash[i].Count != 0)
                    {
                        while(queueCash[i].Count != 0)
                        {
                            queueCash[i].Dequeue().WalletAfterShop(i);
                        }
                    }
                    else Console.WriteLine($"No any customers in #Cash {i}");
                });
            }

            Task.WaitAll(cashTasks);

        }
    }
}
