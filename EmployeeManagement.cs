using System;
using System.Collections.Generic;
using System.Linq;

public class EmployeeManagement
{
    
    public event EventHandler OnEmpResignation;
    public EmployeeManagement()
    {
        employees = new List<IEmployee>();
    }
    public List<IEmployee> employees {get; set;}

    public delegate void EmployeeDelegate();

    public void Add()
    {
        string ans = "yes";
        do
        {
            Console.WriteLine("Enter employee name");
            string? empName = NewMethod();
            Console.WriteLine("Enter your Manager name");
            string? managerName = Console.ReadLine();
            IEmployee emp = new Employee(empName);
            emp.Manager = managerName;
            emp.OnResigned += new EventHandler(TriggerExitProcess);
            employees.Add(emp);
            if (!employees.Where(m => m.Name == managerName).Any())
            {
                Console.WriteLine("Inside");
                IEmployee manager = new Manager(managerName);
                employees.Add(manager);
            }
            Console.WriteLine("Do you want to add another?");
            ans = Console.ReadLine();
        } while (ans.Equals("yes"));

        static string? NewMethod()
        {
            return Console.ReadLine();
        }
    }

    
    public void CalcGraduity()
    {
        //IEmployee.Graduitycalcdeletegate del = ShowGraduity();
         Console.WriteLine("Enter the name of the employee whose Graduity you want to calculate");
        string name = Console.ReadLine();
        employees.ToList().First(m=>m.Name== name).CalcGraduity(ShowGraduity);
    }

    private void ShowGraduity(double amount)
    {
        Console.WriteLine(amount);
    }

    public void Print()
    {
       employees.ForEach(m=>m.PrintEmployeeInfo());
       
    }

    public void Print(Action action)
    {
        action.Invoke();
    }

    public void PrintUsingDelegate(EmployeeDelegate del)
    {
        del();
    }

    private void TriggerExitProcess(object? sender, EventArgs e)
    {
        if (sender != null)
        {
            IEmployee emp = ((IEmployee)sender);
            Console.WriteLine(string.Format("{0} has resigned.", emp.Name));
            IEmployee manager = employees.Where(m=>m.Name== emp.Manager && m.Role == Role.Manager).FirstOrDefault();
            if (manager != null)
            {
                manager.Messages.Add(string.Format("Manager Notificaton: Your team member {0} has resigned", emp.Name));
            }

           OnEmpResignation(emp, new EventArgs());
           

        }
    }

   

    public void Resign()
    {
        string ans ="yes";
        do{
        Console.WriteLine("Enter the name of the employee who has resigned");
        string name = Console.ReadLine();
        employees.ToList().First(m=>m.Name== name).Resign();
        Console.WriteLine("Do you want to continue ?");
        ans = Console.ReadLine();
        }while(ans == "yes");
    }

    public void UpdatePayrollStatus()
    {
        Console.WriteLine("Payroll processing is done");
    }

}