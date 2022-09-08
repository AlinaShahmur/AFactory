using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AFactory.Models;

namespace AFactory.Models
{
    public class usersSessionsBL
    {
        AFactoryEntities db = new AFactoryEntities();
        public usersSession GetSession(int id)
        {
            return db.usersSessions.Where(x => x.ID == id).First();
        }

        public string UpdateSession(int id, usersSession newSession)
        {
            var sess = db.usersSessions.Where(x => x.user_ID == id).First();
            sess.ID = newSession.ID;
            sess.date = newSession.date;
            sess.restActions = newSession.restActions;
            db.SaveChanges();
            return "updated";
        }
    }
}