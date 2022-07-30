using System;
namespace testproject.domain
{
public class NotificationSystem
{
    public event EventHandler OnEmployeeHired;
    public event EventHandler OnEmployeeTransfer;
    private static NotificationSystem _notifier = new NotificationSystem();

    public static NotificationSystem  GetInstance()
    {
        return _notifier;
    }

    public void EmployeeHired(IEmployee employee)
    {
        if (OnEmployeeHired != null)
        OnEmployeeHired(employee, new EventArgs());
    }

     public void EmployeeTransferred(IEmployee employee)
    {
        if (OnEmployeeTransfer != null)
        OnEmployeeTransfer(employee, new EventArgs());
    }
}
}