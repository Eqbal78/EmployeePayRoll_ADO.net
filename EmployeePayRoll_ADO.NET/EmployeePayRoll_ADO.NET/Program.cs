using System;

namespace EmployeePayRoll_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee PayRoll Service.");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.Method1();
            employeeRepo.GetAllEmployees();
        }
    }
}
