// See https://aka.ms/new-console-template for more information
using System;
Console.WriteLine("WELCOME to Employee Portal");


//payroll.CallDashboard();
 EmployeeManagement dashboard = new EmployeeManagement();
        dashboard.Add();        
        dashboard.CalcGraduity();
        Payroll payroll = new Payroll(dashboard);
        payroll.PayrollCallback = dashboard.UpdatePayrollStatus;
        LibraryManagement libraryManagement = new LibraryManagement(dashboard);
        dashboard.Print();        
        //dashboard.employees.ForEach(m=>m.OnResigned+=new EventHandler(EmployeeResignationHandler));
        dashboard.Resign();









