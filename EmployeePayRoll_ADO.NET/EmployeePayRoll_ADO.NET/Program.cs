using System;

namespace EmployeePayRoll_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee PayRoll Service.");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            
            Console.Write("1. Check Database Connection \n2. Retrieve Employee Details \n3. Add Employee Details \n4. Update salary of given employee \n5. Retrieve employees in given start date range \n6. Database Function \n7. Exit");

            Console.Write("\nEnter your choice :");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    employeeRepo.DBconnection();
                    Console.Write("________________________________________________________________________________________________________________________");
                    break;
                case 2:
                    employeeRepo.GetAllEmployees();
                    Console.Write("________________________________________________________________________________________________________________________");
                    break;
                case 3:
                    EmployeeModel model = new EmployeeModel();
                    Console.WriteLine("Enter name :");
                    model.EmployeeName = Console.ReadLine();
                    Console.WriteLine("Enter Basic pay :");
                    model.BasicPay = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Start Date :");
                    model.StartDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter Gender :");
                    model.Gender = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine("Enter Phone Number :");
                    model.PhoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter Department :");
                    model.Department = Console.ReadLine();

                    Console.WriteLine("Enter Address :");
                    model.Address = Console.ReadLine();
                    Console.WriteLine("Enter Deductions :");
                    model.Deductions = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter Taxable Pay :");
                    model.TaxablePay = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter Income Tax :");
                    model.IncomeTax = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter Net Pay :");
                    model.NetPay = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine(employeeRepo.AddEmployee(model) ? "Record inserted successfully " : "Failed");
                    Console.Write("________________________________________________________________________________________________________________________");
                    break;
                case 4:
                    EmployeeModel models = new EmployeeModel();
                    Console.Write("Enter name :");
                    models.EmployeeName = Console.ReadLine();
                    Console.Write("Enter updated Basic pay :");
                    models.BasicPay = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Employee ID :");
                    models.EmployeeID = Convert.ToInt32(Console.ReadLine());
                    employeeRepo.UpdateSalary(models);
                    Console.Write("________________________________________________________________________________________________________________________");
                    break;
                case 5:
                    employeeRepo.GetAllEmployeesFromDate();
                    Console.Write("________________________________________________________________________________________________________________________");
                    break;
                case 6:
                    employeeRepo.ImplementDatabaseFunctions();
                    Console.Write("________________________________________________________________________________________________________________________");
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;

            }
            
        }
    }
}
