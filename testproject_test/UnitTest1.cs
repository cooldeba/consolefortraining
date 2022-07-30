using System;
using testproject;
using Xunit;

namespace testproject_test
{
    public class UnitTest1
    {
        private string _EmpHiredMessage = string.Empty;
        [Fact]
        public void Test1()
        {
            IEmployee.EmployeeHiredDelegate del = new IEmployee.EmployeeHiredDelegate(callback);
            IEmployee employee = new Employee();
            employee.Name = "Rick";
            employee.Hire(del);
            Assert.Equal(employee.Role, Role.Employee);
            Assert.Equal(_EmpHiredMessage, "Rick is hired as a Employee");
        }

        public void callback(string message)
        {
            _EmpHiredMessage = message;
        }
    }


}
