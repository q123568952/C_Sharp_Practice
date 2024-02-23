using DemoShoppingWebsite.Models;
using DemoShoppingWebsite.Models.Service.Impl;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DemoShoppingWebsite.Controllers
{
    public class VerifyController : Controller
    {
       UserServiceImpl userService;
        //GET: Verify
        [HttpPost]
        public ActionResult Login( loginData loginData)
        {
          
             userService = new UserServiceImpl();
            String identifier = loginData.username;
     
            String password = loginData.password;

            UserInfo user = userService.login(identifier, password);

           

            if (user != null)
            {

           
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            else
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    
            }
        }
    }
}