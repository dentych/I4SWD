using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class ReportGetEmployees : IDBHandler
    {
        private EmployeeDB db;

        public ReportGetEmployees(EmployeeDB db)
        {
            this.db = db;
        }

        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            Employee employee;

            db.Reset();

            // Get all employees
            while ((employee = db.GetNextEmployee()) != null)
            {
                employees.Add(employee);
            }

            return employees;
        }
    }
}
