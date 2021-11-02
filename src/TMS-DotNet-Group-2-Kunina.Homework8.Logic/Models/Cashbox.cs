using System;
using System.Collections.Generic;
using TMS_DotNet_Group_2_Kunina.Homework8.Logic.Interfaces;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Models
{
    public class Cashbox : ICashbox
    {
        private bool _isWorking;
        private readonly int _cashBoxDelayTime;
        private List<Customer> _customers;
        private decimal allCash;
       
        public Cashbox()
        {
            Random random = new Random();
            _isWorking = random.Next(0, 5) > 2;
        }

        public int CashBoxIndex { get; set; }

        public bool IsWorking { get; set; }

        public void QueueLength()
        {
            Console.WriteLine($"Customers - 2");
           //return _customers.Count;
        }
    }
}

