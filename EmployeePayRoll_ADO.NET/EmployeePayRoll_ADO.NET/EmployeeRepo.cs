﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayRoll_ADO.NET
{
    public class EmployeeRepo
    {
        /// <summary>
        /// Database server store in string
        /// </summary>
        public static string connectionString = @"Data Source=DESKTOP-AB32E02;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// check database connection methods
        /// </summary>
        public void DBconnection()
        {
            //open server
            connection.Open();
            if (connection.State == ConnectionState.Open)
                Console.WriteLine("Database connection is succesfull & is opened !!");
            else
                Console.WriteLine("Connection is not established !!");
            connection.Close();
        }

        /// <summary>
        /// Fetch all data method
        /// </summary>
        public void GetAllEmployees()
        {
            //instance of EmployeeModel class
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from employee_payroll";
                    //define the SqlCommand object
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    //define SqlDataReader Object
                    SqlDataReader reader = command.ExecuteReader();
                    //check if there are record
                    if (reader.HasRows)
                    {
                        Console.Write("EmpID" + "\t" + "Name" + "\t\t" + "Gender" + "\t");
                        Console.Write("Department" + "\t" + "PhoneNumber" + "\t" + "Address" + "\t\t" + "StartDate" + "\n");
                        while (reader.Read())
                        {
                            model.EmployeeID = reader.GetInt32(0);
                            model.EmployeeName = reader["name"].ToString();
                            model.PhoneNumber = reader["phone"].ToString();
                            model.Address = reader["address"].ToString();
                            model.Department = reader["department"].ToString();
                            model.Gender = Convert.ToChar(reader["Gender"].ToString().Trim());
                            model.BasicPay = Convert.ToInt32(reader["basic_pay"]);
                            model.Deductions = Convert.ToDouble(reader["deduction"]);
                            model.TaxablePay = Convert.ToDouble(reader["taxable_pay"]);
                            model.IncomeTax = Convert.ToDouble(reader["incomeTax"]);
                            model.NetPay = Convert.ToDouble(reader["net_pay"]);
                            model.StartDate = Convert.ToDateTime(reader["start_date"]);
                            
                            Console.Write("{0}\t{1}\t\t{2}\t", model.EmployeeID, model.EmployeeName,model.Gender);
                            Console.Write("{0}\t\t{1}\t{2}\t{3}\n", model.Department, model.PhoneNumber, model.Address, model.StartDate.ToString("dd-mm-yyyy"));
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Add Employee details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    //define the SqlCommand object and pass queary od Storage procedure
                    SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name", model.EmployeeName);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@department", model.Department);
                    command.Parameters.AddWithValue("@phone", model.PhoneNumber);
                    command.Parameters.AddWithValue("@address", model.Address);
                    command.Parameters.AddWithValue("@start_date", model.StartDate);
                    command.Parameters.AddWithValue("@basic_pay",model.BasicPay);
                    command.Parameters.AddWithValue("@deduction", model.Deductions);
                    command.Parameters.AddWithValue("@taxable_pay", model.TaxablePay);
                    command.Parameters.AddWithValue("@incomeTax", model.IncomeTax);
                    command.Parameters.AddWithValue("@net_pay", model.NetPay);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
            
        }
        /// <summary>
        /// update the details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSalary(EmployeeModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spUpdateSalary", this.connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", model.EmployeeID);
                    sqlCommand.Parameters.AddWithValue("@basic_pay", model.BasicPay);
                    sqlCommand.Parameters.AddWithValue("@name", model.EmployeeName);
                    connection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Employee details with date range
        /// </summary>
        public void GetAllEmployeesFromDate()
        {
            //instance of EmployeeModel class
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from employee_payroll where start_date between cast('2020-01-01' as date) and cast(getdate() as date)";
                    //define the SqlCommand object
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    //define SqlDataReader Object
                    SqlDataReader reader = command.ExecuteReader();
                    //check if there are record
                    if (reader.HasRows)
                    {
                        Console.Write("EmpID" + "\t" + "Name" + "\t\t" + "Gender" + "\t");
                        Console.Write("Department" + "\t" + "PhoneNumber" + "\t" + "Address" + "\t\t" + "StartDate" + "\n");
                        while (reader.Read())
                        {
                            model.EmployeeID = reader.GetInt32(0);
                            model.EmployeeName = reader["name"].ToString();
                            model.PhoneNumber = reader["phone"].ToString();
                            model.Address = reader["address"].ToString();
                            model.Department = reader["department"].ToString();
                            model.Gender = Convert.ToChar(reader["Gender"].ToString().Trim());
                            model.BasicPay = Convert.ToInt32(reader["basic_pay"]);
                            model.Deductions = Convert.ToDouble(reader["deduction"]);
                            model.TaxablePay = Convert.ToDouble(reader["taxable_pay"]);
                            model.IncomeTax = Convert.ToDouble(reader["incomeTax"]);
                            model.NetPay = Convert.ToDouble(reader["net_pay"]);
                            model.StartDate = Convert.ToDateTime(reader["start_date"]);

                            Console.Write("{0}\t{1}\t\t{2}\t", model.EmployeeID, model.EmployeeName, model.Gender);
                            Console.Write("{0}\t\t{1}\t{2}\t{3}\n", model.Department, model.PhoneNumber, model.Address, model.StartDate.ToString("dd-mm-yyyy"));
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Do Database operations
        /// </summary>
        public void ImplementDatabaseFunctions()
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select Gender, SUM(basic_pay) as SumOfSalary, MAX(basic_pay) as MaxSalary, MIN(basic_pay) as MinSalary, AVG(basic_pay) as AvgSalary, COUNT(basic_pay) as Count from employee_payroll where Gender='M' or Gender='F' group by Gender";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           
                            char Gender = Convert.ToChar(reader["Gender"].ToString().Trim());
                            int SumOfSalary = reader.GetInt32(1);
                            int MaxSalary = reader.GetInt32(2);
                            int MinSalary = reader.GetInt32(3);
                            int AvgSalary = reader.GetInt32(4);
                            int Count = reader.GetInt32(5);
                            Console.WriteLine("Gender: {0}\tCount: {1}\tMinSalary: {2}\tMaxSalary: {3}\tSumOfSalary: {4}\tAvgSalary: {5}\n", Gender, Count, MinSalary, MaxSalary, SumOfSalary, AvgSalary);
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
