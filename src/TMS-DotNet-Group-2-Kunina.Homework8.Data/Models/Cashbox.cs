using System;
using System.Collections.Generic;

namespace TMS_DotNet_Group_2_Kunina.Homework8.Data.Models
{
    public class Cashbox
    {
        private readonly int _cashBoxIndex;
        private bool _isWorking;
        private readonly int _cashBoxDelayTime;
        private List<Customer> _customers;
        private decimal allCash;
        private readonly object enqueueLocker = new object();
        private readonly object dequeueLocker = new object();

        public Cashbox(int cashBoxIndex, int cashBoxDelayTime)
        {
            _cashBoxIndex = cashBoxIndex;
            _cashBoxDelayTime = cashBoxDelayTime;
            Random random = new Random();
            _isWorking = random.Next(0, 5) > 2;

            if (_isWorking)
            {
                Console.WriteLine($"Cashbox - {_cashBoxIndex} is working");
            }
        }

        public int CashBoxIndex => _cashBoxIndex;

        public bool IsWorking => _isWorking;

        public void QueueLength()
        {
            Console.WriteLine($"Customers - {_customers.Count}");
           //return _customers.Count;
        }
    }
}

