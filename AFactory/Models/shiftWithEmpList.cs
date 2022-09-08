using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AFactory.Models
{
    public class shiftWithEmpList
    {
        public int ID { get; set; }
        public System.DateTime date { get; set; }
        public int startTime { get; set; }
        public int EndTime { get; set; }
        public List<employee> employeesInShift { get; set; }
    }
}