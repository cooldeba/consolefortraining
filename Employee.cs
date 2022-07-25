using System;
using System.Collections.Generic;

internal class Employee : IEmployee
{
    public delegate void Graduitycalcdeletegate(double gamount);
    
    public string Name { get; set; }
    public double Salary { get; set; }

    public string UnitHR {get; set;}
    public string Manager {get; set;}
    public IList<string> Messages { get; set; }

    public Role Role {get; set;}

    public event EventHandler OnResigned;

    public Employee(string name)
    {
        Name = name;
        Messages = new List<string>();
    }

    public void PrintEmployeeInfo()
    {
        Console.WriteLine(string.Format("Name:{0},Salary:{1}, Messages:{2}",Name, Salary, Messages.Count>0?Messages[0]:"No Message"));
    }

    public void Resign()
    {
        OnResigned(this, new EventArgs());
    }   

    public void CalcGraduity(IEmployee.Graduitycalcdeletegate callback)
    {
         callback(120000);
    }
}