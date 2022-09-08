using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AFactory.Models;


namespace AFactory.Models
{
    public class ShiftBL
    {
        AFactoryEntities db = new AFactoryEntities();
        public List<shiftWithEmpList> GetAll()
        {
            var res = db.shifts.ToList();
            List<shiftWithEmpList> list = new List<shiftWithEmpList>();
            foreach (shift sh in res)
            {
                shiftWithEmpList shift = new shiftWithEmpList();
                shift.ID = sh.ID;
                shift.date = sh.date;
                shift.startTime = sh.startTime;
                shift.EndTime = sh.EndTime;
                shift.employeesInShift = new List<employee>();
                var empSh = db.employeesShifts.Where(x => x.shiftID == sh.ID).ToList();
                if (empSh.Count > 0) {
                    foreach (employeesShift empShift in empSh)
                    {
                        var emp = db.employees.Where(x => x.ID == empShift.employeeID).First();
                        shift.employeesInShift.Add(emp);

                    }
                }
    
                list.Add(shift);
            }
            return list;
        }
        public shiftWithEmpList GetShiftWithEmpList(int id) 
        {
            var res1 = db.shifts.Where(x => x.ID == id).First();
            var res2 = db.employeesShifts.Where(x => x.shiftID == id).ToList();
            shiftWithEmpList shift = new shiftWithEmpList();
            shift.ID = res1.ID;
            shift.date = res1.date;
            shift.startTime = res1.startTime;
            shift.EndTime = res1.EndTime;
            shift.employeesInShift = new List<employee>();
            foreach (employeesShift empShift in res2) {
                var emp = db.employees.Where(x => x.ID == empShift.employeeID).First();               
                shift.employeesInShift.Add(emp);
            }

            return shift;

        }

        public string AddShift(System.DateTime date, int startTime, int EndTime) 
        {
            shift obj = new shift();
            obj.date = date;
            obj.startTime = startTime;
            obj.EndTime = EndTime;
            db.shifts.Add(obj);
            db.SaveChanges();
            return "added";
        }

    }
}