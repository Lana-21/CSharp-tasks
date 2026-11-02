using System;
using System.Collections.Generic;
using System.Text;

namespace Home12List.services
{
    public class ServiceEmployeeAuth
    {
        private Dictionary<string, string> employees = new();

        public ServiceEmployeeAuth(Dictionary<string, string> newEmployees)
        {
            employees = newEmployees;
        }
        public bool AddEmployee(string login, string password)
        {
            if (!employees.ContainsKey(login))
            {
                employees.Add(login, password);
                return true;
            }
            return false;
        }
        public bool RemoveEmployee(string login)
        {
            return employees.Remove(login);
        }
        public bool UpdatePassword(string login, string newPassword)
        {
            if (employees.ContainsKey(login))
            {
                employees[login] = newPassword;
                return true;
            }
            return false;
        }
        public string GetPassword(string login)
        {
            if (employees.ContainsKey(login))
            {
                return employees[login];
            }
            return null;
        }
        public Dictionary<string, string> GetAllEmployees()
        {
            return employees;
        }
    }
}
