using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AFactory.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AFactory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        EmployeeBL bl = new EmployeeBL();
        // GET: Employee
        public List<EmployeeWithDepName> Get()
        {
            return bl.GetAllData();
        }

        [System.Web.Http.Route("api/employee/{id:int}")]
        [System.Web.Http.HttpGet]
        public EmployeeWithDepName GetById(int id)
        {
            return bl.GetData(id);
        }

        [System.Web.Http.Route("api/employee/{searchParams}")]
        [System.Web.Http.HttpGet]
        public List<EmployeeWithDepName> GetRes(string searchParams)
        {
            return bl.GetSearchRes(searchParams);
        }

        [System.Web.Http.Route("api/employee/{id:int}")]
        public string Put(int id, EmployeeWithDepName updEmp)
        {
            return bl.UpdateData(id, updEmp.firstName, updEmp.lastName, updEmp.startWorkYear, updEmp.DepartmentName);
        }


        [System.Web.Http.Route("api/employee/{id:int}")]
        public string Delete(int id)
        {
            return bl.DeleteData(id);
        }
    }
}
