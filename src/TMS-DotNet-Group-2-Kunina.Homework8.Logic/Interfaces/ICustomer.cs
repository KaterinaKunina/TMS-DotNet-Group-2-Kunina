using System.Collections.Generic;
using TMS_DotNet_Group_2_Kunina.Homework8.Data.Enums;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Models;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Interfaces
{
    public interface ICustomer
    {
        public int CustomerID { get; set; }

        public decimal Cash { get; set; }

        public List<Product> Cart { get; set; }

        public int DiscountCard { get; set; }

        public void CreatProductList(Dictionary<Products, Product> products);

        public void BuyProducts();
    }
}

