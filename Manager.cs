public class Manager:IEmployee, IEmployeeExtension
{
    public Manager()
    {
        Name = string.Empty;
    }
    public string Name {get; set;}
    public double Salary {get; set;}
    public void PrintEmployeeInfo()
    {
        Console.WriteLine(Name);
    }

    public void PrintSalaryInfo()
    {
        Console.WriteLine(Salary);
    }
} 