using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AFactory.Models;

namespace AFactory.Models
{
    public class DepartmentBL
    {
        AFactoryEntities db = new AFactoryEntities();

        public List<department> GetAll()
        {
            return db.departments.ToList();
        }


        public department GetOne(int id)
        {
            return db.departments.Where(x => x.ID == id).First();
        }

        public string AddDep( string name, Nullable<int> manager)
        {
            department dep = new department();
            dep.name = name;
            dep.manager = manager;
            db.departments.Add(dep);
            db.SaveChanges();
            return "created";
        }

        public string Update(int id, string name, Nullable<int> manager)
        {
            var dep = db.departments.Where(x => x.ID == id).First();
            dep.name = name;
            dep.manager = manager;
            db.SaveChanges();
            return "updated";
        }

        public string Delete(int id)
        { 
            var dep = db.departments.Where(x => x.ID == id).First();
            if (dep.manager == null)
            {
                db.departments.Remove(dep);
                db.SaveChanges();
                return "deleted";
            }
            else {
                return "Impossible to delete department with manager";
            }



        }
    }
}