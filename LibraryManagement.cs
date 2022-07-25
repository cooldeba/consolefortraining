using System;

public class LibraryManagement
{
    private EmployeeManagement _dashboard ;
    public LibraryManagement(EmployeeManagement dashboard)
    {     
        _dashboard = dashboard;
        _dashboard.OnEmpResignation += new EventHandler(EmployeeResignationHandler);
    }  

    public void EmployeeResignationHandler(object sender, EventArgs args)
    {
        Console.WriteLine(string.Format("Library clearance process for employee {0} has started", ((IEmployee)sender).Name));
    }

    
}