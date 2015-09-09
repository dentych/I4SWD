using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    public enum ReportOutputFormatType
    {
        NameFirst,
        SalaryFirst
    }

    internal class ReportGenerator
    {
        private readonly EmployeeDB _employeeDb;
        private ReportFormatEmployees _currentOutputFormat;
        private IDBHandler dbhandler;


        public ReportGenerator(EmployeeDB employeeDb, ReportFormatEmployees format, IDBHandler dbhandler)
        {
            if (employeeDb == null) throw new ArgumentNullException("employeeDb");
            _currentOutputFormat = format;
            _employeeDb = employeeDb;
            this.dbhandler = dbhandler;
        }


        public void CompileReport()
        {
            List<Employee> employees = dbhandler.GetEmployees();

            foreach (var employee in employees)
            {
                _currentOutputFormat.Print(employee);
            }
        }
    }
}