using System;
using System.Collections.Generic;
using System.Linq;

namespace CashSimulator
{
    public class Customer
    {
        public int id { get; set; }

        public double wallet { get; set; }

        public Dictionary<int, Product> basket { get; set; }

        private const int MaxProductsCount = 10;

        public Customer()
        {
            id = 0;
            wallet = 0;
            basket = null;
        }

        public Customer(int id, double wallet) : this()
        {
            this.id = id;
            this.wallet = wallet;
        }

        public void MakePurchases()
        {
            Random random = new();
            basket = Basket.FillBasket(random.Next(MaxProductsCount));
            RemoveProductFromBasket();
        }

        public bool CheckEnoughMoneyToPay()
        {
            return basket.Sum(v => v.Value.Price) <= wallet;
        }


        public Dictionary<int, Product> RemoveProductFromBasket()
        {
            if (!CheckEnoughMoneyToPay())
            {
                while (basket.Sum(v => v.Value.Price) > wallet)
                {
                    if (basket.Max(v => v.Value.Price) <= wallet)
                    {
                        RemoveProductWithFixPrice(basket.Min(v => v.Value.Price));
                    }
                    else
                    {
                        RemoveProductWithFixPrice(basket.Max(v => v.Value.Price));
                    }
                }
            }
            return basket;
        }

        private void RemoveProductWithFixPrice(double price)
        {
            foreach (var kvp in basket.Where(kvp => kvp.Value.Price == price))
            {
                basket.Remove(kvp.Key);
            }
        }

        public double WalletAfterShop(int threadId)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\n========================================");
            Console.WriteLine("Customer id = {0} and Wallet before shop: {1}", id, wallet);
            //RemoveProductFromBasket();
            wallet -= basket.Sum(v => v.Value.Price);
            Console.WriteLine("Customer id = {0} and  Wallet after shop = {1} Сheckout number {2}", id, wallet, threadId);
            return wallet;
        }

        public void ListOfProductsInBasket()
        {
            Console.WriteLine("\n********************************************************************");
            Console.WriteLine("\tList of products in basket for CUSTOMER = {0} and WALLET = {1}", id, wallet);
            Console.WriteLine("**********************************************************************");
            for (int i = 0; i < basket.Count; i++)
            {
                KeyValuePair<int, Product> pair = basket.ElementAt(i);
                Console.WriteLine("key: " + pair.Key + ", value: Id = " + pair.Value.Id + " ProductName = " + pair.Value.ProductName
                    + " Price = " + pair.Value.Price);
            }
        }
    }
}
