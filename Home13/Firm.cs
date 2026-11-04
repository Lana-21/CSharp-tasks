using System;
using System.Collections.Generic;
using System.Text;

namespace Practice13LINQ
{
    public record Firm(string Name, DateTime FoundingDate, string BusinessProfile, string DirectorFullName, int EmployeeCount, string Address, List<Employee> Employees);
}

