using System;
namespace testproject.domain
{
public class LibraryManagement
{
     NotificationSystem _notifier = NotificationSystem.GetInstance();
    
    public LibraryManagement()
    { 
        _notifier.OnEmployeeTransfer += new EventHandler(EmployeeHiringHandler);
    }  

    public void EmployeeHiringHandler(object sender, EventArgs args)
    {
        Console.WriteLine(string.Format("Library membership process for employee {0} has started", ((IEmployee)sender).Name));
    }

    
}
}