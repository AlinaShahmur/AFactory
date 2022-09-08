using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AFactory.Models
{
    public class EmployeeShiftWithTime

    {
        public Nullable<int> employeeID { get; set; }
        public Nullable<int> shiftID { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> startTime { get; set; }
        public Nullable<int> EndTime { get; set; }
    }
}