using System;
using TMS_DotNet_Group_2_Kunina.Homework8.Data.Enums;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Models
{
    public class Product
    {
        private readonly Products _name;
        private readonly decimal _price;
        private readonly Priorities _priority;

        public Product(Products name, decimal price, Priorities priority)
        {
            _name = name;
            _price = price;
            _priority = priority;
        }

        public Products Name => _name;

        public decimal Price => _price;

        public Priorities Priority => _priority;
    }
}

