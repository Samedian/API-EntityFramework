using Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal class ModelManager
    {
        public CreateAccount ConvertAccount(CreateAccountEntity accountEntity)
        {
            CreateAccount account = new CreateAccount();
            account.AccountNumber = accountEntity.AccountNumber;
            account.BankName = accountEntity.BankName;
            account.CustomerName = accountEntity.CustomerName;
            account.DailyTransactionLimit = accountEntity.DailyTransactionLimit;

            return account;
        }

        public CustomerDetail ConvertCustomer(CustomerDetailEntity customerEntity)
        {
            CustomerDetail customer = new CustomerDetail();
            customer.CustomerName = customerEntity.CustomerName;
            customer.Pannumber = customerEntity.Pannumber;

            return customer;
        }
    }
}
