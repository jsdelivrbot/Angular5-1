﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using aspwebapp1.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace aspwebapp1.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        public IdentityResult Register(AccountModel model)
        {
            var userStore = new UserStore<ApplicationUser>
                (new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>
                (userStore);
            var user = new ApplicationUser()
            {UserName=model.UserName,Email=model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };


            IdentityResult result = manager.Create(user, model.Password);
            return result;
        }
    }
}
