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
    public class usersSessionsController : ApiController
    {
        usersSessionsBL bl = new usersSessionsBL();
        // GET: usersSessions


        public usersSession Get(int id)
        {
            return bl.GetSession(id);
        }

        public string Put(int id, usersSession newSession)
        {
            return bl.UpdateSession(id, newSession);
        }

    }
}
