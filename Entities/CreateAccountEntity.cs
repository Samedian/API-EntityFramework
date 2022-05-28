using System;

namespace Entities
{
    public class CreateAccountEntity
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal DailyTransactionLimit { get; set; }
        public string BankName { get; set; }

    }
}
