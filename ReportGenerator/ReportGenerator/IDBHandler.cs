﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{
    interface IDBHandler
    {
        List<Employee> GetEmployees();
    }
}
