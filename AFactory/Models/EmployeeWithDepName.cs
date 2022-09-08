using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AFactory.Models
{
    public class EmployeeWithDepName
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int startWorkYear { get; set; }

        public string DepartmentName { get; set; }
    }
}