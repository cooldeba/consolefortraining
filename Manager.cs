using System;

internal class Manager:Employee, IEmployeeExtension
{ 
    internal Manager(string name):base(name)
    {       
          base.Role = Role.Manager;   
    }
  
  

    public void PrintSalaryInfo()
    {
        Console.WriteLine(Salary);
    }

   
} 