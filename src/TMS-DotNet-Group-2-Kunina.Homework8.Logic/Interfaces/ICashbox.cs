namespace TMS_DotNet_Group_2_Kunina.Homework8.Logic.Interfaces
{
    public interface ICashbox
    {
        public int CashBoxIndex { get; set; }

        public bool IsWorking { get; set; }

        public int QueueLength();

        public void TakeQueue(ICustomer customer);

        public void GetMoney();
    }
}

