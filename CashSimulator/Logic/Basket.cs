using System;
using System.Collections.Generic;
using System.Linq;

namespace CashSimulator
{
    public class Basket
    {
        public static Dictionary<int, Product> FillBasket(int countProduct)
        {
            Random random = new();
            Dictionary<int, Product> result = new();

            for (int i = 0; i < countProduct; i++)
            {
                int index = random.Next(1, Product.Product_ToDictionary().Count);
                result.Add(i, Product.Product_ToDictionary()[index]);
            }

            return result;
        }
    }
}
