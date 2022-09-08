using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AFactory.Models
{
    public class LoginBL
    {
        AFactoryEntities db = new AFactoryEntities();
        public user CheckUser(string userName, string password)
        {
            var res = db.users.Where(x => x.userName == userName && x.password == password);
            if (res.Count() > 0)
            {
                return res.First();
            }
            else {
                return null;
            }
        }


    }
}