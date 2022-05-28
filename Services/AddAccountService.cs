using System;
using Entities;
using Repository;

namespace Services
{
    public class AddAccountService
    {
        public void AddAcc(Account accountEntity)
        {
            AddAccData account = new AddAccData();
            account.AddData(accountEntity);
        }
    }
}
