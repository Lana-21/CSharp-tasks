using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12List.models
{
    public record class Employee(
       string FirstName,
       string LastName,
       string Position,
       int Wages,
       string Email);
}
