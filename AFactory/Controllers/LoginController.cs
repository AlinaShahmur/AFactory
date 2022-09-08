using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Cors;
using AFactory.Models;


namespace AFactory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        LoginBL bl = new LoginBL();
        // GET: Login
        public user Post(user checkUs)
        {
            return bl.CheckUser(checkUs.userName, checkUs.password);
        }     
    }
}
