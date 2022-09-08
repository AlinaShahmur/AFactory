using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using AFactory.Models;

namespace AFactory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ShiftController : ApiController
    {
        ShiftBL bl = new ShiftBL();

        public List<shiftWithEmpList> Get()
        {
            return bl.GetAll();
        }
        public shiftWithEmpList Get(int id)
        {
            return bl.GetShiftWithEmpList(id);
        }

        public string Post(shift newShift)
        {
            return bl.AddShift(newShift.date, newShift.startTime, newShift.EndTime);
        }

    }
}
