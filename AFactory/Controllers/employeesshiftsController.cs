using AFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AFactory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class employeesshiftsController : ApiController
    {


        EmployeesShiftsBL bl = new EmployeesShiftsBL();
        // GET: Shift
        public List<employeesShift> Get()
        {
            return bl.GetAllData();
        }
        public List<EmployeeShiftWithTime> Get(int id)
        {
                return bl.GetEmpShiftsTime(id);

        }

        public string Post(employeesShift empSh) 
        {
            return bl.Create(empSh.employeeID, empSh.shiftID);

        }

        public string Delete(int id)
        {
            return bl.DeleteData(id);
        }

    }
}
