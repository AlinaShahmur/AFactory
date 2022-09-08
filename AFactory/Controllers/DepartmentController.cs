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
    public class DepartmentController : ApiController
    {
        DepartmentBL bl = new DepartmentBL();
       
        public List<department> Get()
        {
            return bl.GetAll();
        }

        public department Get(int id)
        {
            return bl.GetOne(id);
        }

        public string Post(department dep)
        {
            return bl.AddDep(dep.name, dep.manager);
        }

        public string Put(int id, department dep)
        {
            return bl.Update(id, dep.name, dep.manager);
        }
        public string Delete(int id)
        {
            return bl.Delete(id);
        }

    }
}
