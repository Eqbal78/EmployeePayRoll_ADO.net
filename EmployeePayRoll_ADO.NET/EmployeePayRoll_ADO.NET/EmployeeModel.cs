using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRoll_ADO.NET
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public char Gender { get; set; }
      
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public int BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
    }
}
