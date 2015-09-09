using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    abstract class ReportFormatEmployees
    {
        public abstract void Print(Employee e);

        protected void PrintLine()
        {
            Console.WriteLine("------------------");
        }

        protected void PrintName(Employee e)
        {
            Console.WriteLine("Name: {0}", e.Name);
        }

        protected void PrintSalary(Employee e)
        {
            Console.WriteLine("Salary: {0}", e.Salary);
        }
    }

    class ReportFormatNameFirst : ReportFormatEmployees
    {
        public override void Print(Employee e)
        {
            PrintLine();
            PrintName(e);
            PrintSalary(e);
            PrintLine();
        }
    }

    class ReportFormatSalaryFirst : ReportFormatEmployees
    {
        public override void Print(Employee e)
        {
            PrintLine();
            PrintSalary(e);
            PrintName(e);
            PrintLine();
        }
    }
}
