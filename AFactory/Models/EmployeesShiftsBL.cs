using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AFactory.Models
{
    public class EmployeesShiftsBL
    {
        AFactoryEntities db = new AFactoryEntities();

        public List<employeesShift> GetAllData()
        {
            return db.employeesShifts.ToList();
        }

        public List<EmployeeShiftWithTime> GetEmpShiftsTime(int id) {
            var res = (from employeeShift in db.employeesShifts
                       join shift in db.shifts on
                       employeeShift.shiftID equals shift.ID
                       select new EmployeeShiftWithTime
                       {
                           employeeID = employeeShift.employeeID,
                           shiftID = shift.ID,
                           date = shift.date,
                           startTime = shift.startTime,
                           EndTime = shift.EndTime,
                       }).Where(x => x.employeeID == id).ToList();
            return res;
        }

        public List <employeesShift>  GetData(int empID) {
            return db.employeesShifts.Where(x => x.employeeID == empID).ToList();
        }

        public string Create(int employeeID, int shiftID)
        {
            employeesShift empSh = new employeesShift();
            empSh.employeeID = employeeID;
            empSh.shiftID = shiftID;
            db.employeesShifts.Add(empSh);
            db.SaveChanges();
            return "created";
        }
        public string DeleteData(int id)
        {

           var shifts = db.employeesShifts.Where(x => x.employeeID == id).ToList();
            foreach (var shift in shifts) {
                db.employeesShifts.Remove(shift);
                db.SaveChanges();
            }
            return "deleted";
        }


    }
}