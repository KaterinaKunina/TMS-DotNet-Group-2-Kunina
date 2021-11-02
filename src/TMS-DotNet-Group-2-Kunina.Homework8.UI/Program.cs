using System;
using TMS_DotNet_Group_2_Kunina.Homework8.Data;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Interfaces;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Managers;

namespace TMS_DotNet_Group_2_Kunina.Homework8.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to our mall");
            Console.WriteLine("Input the number of cash desks that work");
            string inputCashDesks = Console.ReadLine();
            CheckInputValue(inputCashDesks, out int numberCashDesks);

            Console.WriteLine("Input the number of customers");
            string inputСustomers = Console.ReadLine();
            CheckInputValue(inputCashDesks, out int numberCustomers);

            IShopManager shopManager = new ShopManager();
            shopManager.Run(numberCustomers, numberCashDesks);

        }

        private static void CheckInputValue(string inputValue, out int outputValue)
        {
            bool stop = false;

            do
            {
                if (!int.TryParse(inputValue, out outputValue))
                {
                    Console.WriteLine($"Incorrect value. Try again");
                }
                else
                {
                    stop = true;
                }
            } while (!stop);
        }
    }
}

