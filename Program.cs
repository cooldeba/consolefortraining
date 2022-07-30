// See https://aka.ms/new-console-template for more information
using System;
using testproject.domain;

namespace testproject
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME to Employee Portal");


            //payroll.CallDashboard();
            EmployeeManagement dashboard = new EmployeeManagement();

            //  dashboard.Add();        
            //  dashboard.CalcGraduity();
            Payroll payroll = new Payroll();
            payroll.PayrollCallback = dashboard.UpdatePayrollStatus;
            LibraryManagement libraryManagement = new LibraryManagement();
            dashboard.init();
        }
    }
}


