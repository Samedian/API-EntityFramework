using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Model
{
    public partial class Withdraw
    {
        public int? AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual CreateAccount AccountNumberNavigation { get; set; }
    }
}
