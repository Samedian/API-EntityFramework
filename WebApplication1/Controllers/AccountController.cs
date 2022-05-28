using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost]
        [Authorize]

        public void Save(Account accountdata)
        {
            AddAccountService account = new AddAccountService();
            account.AddAcc(accountdata);

        }
       [HttpGet]
       [Authorize]
        public string Get()
        {
            return "Hii";
        }

    }
}
