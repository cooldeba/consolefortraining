using System;
using System.Collections.Generic;
namespace testproject
{
    public class Employee : IEmployee
    {
        private const double BasicPerYear = 100000;

        public delegate void EmployeeHiredDelegate(string message);

        public string Name { get; set; }
        public double Salary { get; set; }
        public double Graduity { get; set; }

        public string UnitHR { get; set; }
        public string Manager { get; set; }

        public string AccountCode { get; set; }
        public int YearsOfExperience { get; set; }
        public IList<string> Messages { get; set; }

        public Role Role { get; set; }

        public event EventHandler OnTransferd;

        public Employee()
        {
            Messages = new List<string>();
            Role = Role.Employee;
        }

        public void Hire(IEmployee.EmployeeHiredDelegate hiredDelegate)
        {
            this.CalcSalary();
            this.CalcGraduity();
            hiredDelegate(string.Format("{0} is hired as a {1}", Name, Role));
        }

        public void PrintEmployeeInfo()
        {
            Console.WriteLine(string.Format("Name:{0},Role:{1},Salary:{2}, Graduity:{3}, Messages:{4}", Name, Role, Salary, Graduity, Messages.Count > 0 ? Messages[0] : "No Message"));
        }

        public void Transfer()
        {
            OnTransferd(this, new EventArgs());
        }

        public void CalcGraduity()
        {
            this.Graduity = 10000;
        }

        public void CalcSalary()
        {
            Salary = BasicPerYear * YearsOfExperience;
        }


        public void PrintSalaryInfo()
        {
            Console.WriteLine(Salary);
        }
    }
}