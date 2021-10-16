using EmployeePayRoll_ADO.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeePayRollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenNameAndUpdatedSalary_UpdateSalaryMethod_ShouldReturnTrue()
        {
            EmployeeRepo repo = new EmployeeRepo();
            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = "Charlie";
            model.EmployeeID = 3;
            model.BasicPay = 300000;
            bool updateResult = repo.UpdateSalary(model);
            bool expected = true;
            Assert.AreEqual(updateResult, expected);
        }
    }
}
