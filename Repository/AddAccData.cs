using Entities;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AddAccData
    {
        public void AddData(Account account)
        {
            ModelManager modelManager = new ModelManager();
            CreateAccount acc= modelManager.ConvertAccount(account.CreateAccountEntity);
            CustomerDetail cust = modelManager.ConvertCustomer(account.CustomerDetailEntity);

            using (var context = new WebAPIContext())
            {
                context.CreateAccounts.Add(acc);
                context.SaveChanges();

            }

            using(var context = new WebAPIContext())
            {
                var data = (from d in context.CustomerDetails where cust.CustomerName == d.CustomerName && d.Pannumber == cust.Pannumber select d).FirstOrDefault();

                if (data != null)
                {
                    context.CustomerDetails.Add(cust);
                    context.SaveChanges();
                }
            }

        }
    }
}
