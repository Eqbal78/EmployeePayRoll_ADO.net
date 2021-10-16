using System;

namespace EmployeePayRoll_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee PayRoll Service.");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.DBconnection();


            EmployeeModel model = new EmployeeModel();
            //model.EmployeeName = "Twinkle";
            //model.BasicPay = 75000;
            //model.StartDate = Convert.ToDateTime("2020-11-03");
            //model.Gender = 'F';
            //model.PhoneNumber = "7852149630";
            //model.Department = "IT";
            //model.Address = "Lucknow";
            //model.Deductions = 4540;
            //model.TaxablePay = 3204;
            //model.IncomeTax = 4500;
            //model.NetPay = 52000;
            //Console.WriteLine(employeeRepo.AddEmployee(model) ? "Record inserted successfully " : "Failed");
            //employeeRepo.GetAllEmployees();

            //updation the basic pay with given name and employee id
            model.EmployeeID = 1;
            model.BasicPay = 5000000;
            model.EmployeeName = "natalie";
            Console.WriteLine(employeeRepo.UpdateSalary(model) ? "updated successfully" : "failed to update");


        }
    }
}
