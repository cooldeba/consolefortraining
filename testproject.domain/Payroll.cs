using System;
namespace testproject
{
public class Payroll
{
     NotificationSystem _notifier = NotificationSystem.GetInstance();
    public delegate void Payrolldelegate();
    public Payrolldelegate PayrollCallback {get; set;}   
    public Payroll()
    {            
        _notifier.OnEmployeeTransfer += new EventHandler(EmployeeTransferationHandler);
        _notifier.OnEmployeeHired +=  new EventHandler(EmployeeHiringHandler);
    }  

    public void EmployeeHiringHandler(object sender, EventArgs args)
    {
        Console.WriteLine(string.Format("Payroll processing for hiring of employee {0} has started", ((IEmployee)sender).Name));
        PayrollCallback();
    }

    public void EmployeeTransferationHandler(object sender, EventArgs args)
    {
        Console.WriteLine(string.Format("Payroll processing for tranfer of employee {0} has started", ((IEmployee)sender).Name));
        PayrollCallback();
    }

    
}
}