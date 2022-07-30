using System;
using System.Collections.Generic;
namespace testproject.domain
{
    public interface IEmployee
    {
        IList<string> Messages { get; set; }
        delegate void EmployeeHiredDelegate(string message);
        string Name { get; set; }
        double Salary { get; set; }
        string UnitHR { get; set; }
        string Manager { get; set; }
        string AccountCode { get; set; }
        int YearsOfExperience { get; set; }
        event EventHandler OnTransferd;
        void PrintEmployeeInfo();
        Role Role { get; set; }
        void Transfer();

        void CalcGraduity();
        void Hire(EmployeeHiredDelegate salaryDelegate);
        void PrintSalaryInfo();

    }
}