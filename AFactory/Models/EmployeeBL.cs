using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AFactory.Models
{
    public class EmployeeBL
    {
        AFactoryEntities db = new AFactoryEntities();

        public List<EmployeeWithDepName> GetAllData() {
            var res = (from employee in db.employees
                       join department in db.departments
                       on employee.departmentID equals department.ID
                       select new EmployeeWithDepName
                       {
                           ID = employee.ID,
                           firstName = employee.firstName,
                           lastName = employee.lastName,
                           startWorkYear = employee.startWorkYear,
                           DepartmentName = department.name

                       }).ToList();
            return res;
        }

        public EmployeeWithDepName GetData(int id)
        {
            var res = (from employee in db.employees
                       join department in db.departments
                       on employee.departmentID equals department.ID
                       select new EmployeeWithDepName
                       {
                           ID = employee.ID,
                           firstName = employee.firstName,
                           lastName = employee.lastName,
                           startWorkYear = employee.startWorkYear,
                           DepartmentName = department.name

                       }).Where(x => x.ID == id).ToList().First();
            return res;
        }

        public List<EmployeeWithDepName> GetSearchRes(string searchParams)
        {
            var res = (from employee in db.employees
                       join department in db.departments
                       on employee.departmentID equals department.ID
                       select new EmployeeWithDepName
                       {
                           ID = employee.ID,
                           firstName = employee.firstName,
                           lastName = employee.lastName,
                           startWorkYear = employee.startWorkYear,
                           DepartmentName = department.name

                       }).Where(x => x.firstName.Contains(searchParams) || x.lastName.Contains(searchParams) || x.DepartmentName.Contains(searchParams)).ToList();
            return res;
        }

        public string UpdateData(int id, string firstName, string lastName, int startWorkYear, string departmentName)
        {          
            var emp = db.employees.Where(x => x.ID == id).First();
            var depID = db.departments.Where(x => x.name == departmentName).First().ID;
            emp.firstName = firstName;
            emp.lastName = lastName;
            emp.startWorkYear = startWorkYear;
            emp.departmentID = depID;
            db.SaveChanges();
            return "updated";
        }

        public string DeleteData(int id)
        {
            var emp = db.employees.Where(x => x.ID == id).First();
            db.employees.Remove(emp);
            db.SaveChanges();
            return "deleted";
        }
    }
}