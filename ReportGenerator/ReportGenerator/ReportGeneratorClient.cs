using System;

namespace ReportGenerator
{
    internal class ReportGeneratorClient
    {
        private static void Main()
        {
            var db = new EmployeeDB();

            // Add some employees
            db.AddEmployee(new Employee("Anne", 3000));
            db.AddEmployee(new Employee("Berit", 2000));
            db.AddEmployee(new Employee("Christel", 1000));

            var reportGenerator = new ReportGenerator(db, new ReportFormatSalaryFirst(), new ReportGetEmployees(db));

            reportGenerator.CompileReport();
        }
    }
}