using ConsoleApp12List.models;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4List.services
{
    public class ServiceListEmployee
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public ServiceListEmployee(List<Employee> employees)
        {
            Employees = employees;
        }
        public void AddEmployee(Employee employee)//??
        {
            if (!Employees.Contains(employee))
            {
                Employees.Add(employee);
            }
        }
        public string RemoveEmployee(int id)//Employee employee)
        {
            //return (Employees.Remove(employee))?
            //    $"{employee} removed":$"Error: not found {employee.LastName}";
            if (id < 0 || id >= Employees.Count)
            {
                return $"Error: not found {id}";
            }
            Employees.RemoveAt(id);//Remove(Employees[id]);
            return $"{Employees[id]} removed";
        }
        public bool UpdateEmployee(int index, Employee updatedEmployee)
        {
            if (index < 0 || index >= Employees.Count) return false;
            Employees[index] = updatedEmployee;
            return true;
        }
        public List<Employee> SearchByLastName(string lastName)
        {
            List<Employee> result = new();
            foreach (var e in Employees)
            {
                if (e.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase)) result.Add(e);
            }
            return result;
        }
        public List<Employee> SearchByPosition(string position)
        {
            List<Employee> result = new();
            foreach (var e in Employees)
            {
                if (e.Position.Contains(position, StringComparison.OrdinalIgnoreCase)) result.Add(e);
            }
            return result;
        }
        public void SortByFirstName()
        {
            Employees.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
        }
        public void SortByLastName()
        {
            Employees.Sort((a, b) => a.LastName.CompareTo(b.LastName));
        }
        public void SortByWages()
        {
            Employees.Sort((a, b) => b.Wages - a.Wages);
        }
        public void SortByPosition()
        {
            Employees.Sort((a, b) => a.Position.CompareTo(b.Position));
        }
        public void ShowList()
        {
            int i = 0;
            foreach (Employee emp in Employees)
            {
                WriteLine($"{++i}. {emp}");
            }
        }
    }
}
