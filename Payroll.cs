using System;

public class Payroll
{
    public delegate void Payrolldelegate();
    public Payrolldelegate PayrollCallback {get; set;}
    private EmployeeManagement _dashboard ;
    public Payroll(EmployeeManagement dashboard)
    {     
        _dashboard = dashboard;
        _dashboard.OnEmpResignation += new EventHandler(EmployeeResignationHandler);
    }  

    public void EmployeeResignationHandler(object sender, EventArgs args)
    {
        Console.WriteLine(string.Format("Full and final settlement for employee {0} has started", ((IEmployee)sender).Name));
        PayrollCallback();
    }

    
}