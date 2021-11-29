using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Models
{
    public class Basket
    {
        public static Dictionary<int, ProductKateShop> FillBasket(int countProduct)
        {
            Random random = new();
            Dictionary<int, ProductKateShop> result = new();

            for (int i = 0; i < countProduct; i++)
            {
                int index = random.Next(1, ProductKateShop.Product_ToDictionary().Count);
                result.Add(i, ProductKateShop.Product_ToDictionary()[index]);
            }

            return result;
        }
    }
}

