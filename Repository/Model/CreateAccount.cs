using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Model
{
    public partial class CreateAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal DailyTransactionLimit { get; set; }
        public string BankName { get; set; }
    }
}
