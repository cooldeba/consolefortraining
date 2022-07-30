using System;
using System.Collections.Generic;
using System.Linq;
namespace testproject.domain
{
    public class EmployeeManagement
    {

        NotificationSystem _notifier = NotificationSystem.GetInstance();


        public EmployeeManagement()
        {
            employees = new List<IEmployee>();
        }
        public List<IEmployee> employees { get; set; }

        public delegate void EmployeeDelegate();

        public void init()
        {
            string choice = "1";
            double choiceInDigit;

            do
            {
                //Console.Clear();
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("1. Hire Employee");
                Console.WriteLine("2. Transfer Employee");
                Console.WriteLine("3. Assign To Account");
                Console.WriteLine("4. Print");
                Console.WriteLine("5. Print All");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice");
                choice = Console.ReadLine();
                if (!double.TryParse(choice, out choiceInDigit))
                {
                    Console.WriteLine("Invalid Choice");
                    continue;
                }

                switch (choiceInDigit)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Transfer();
                        break;
                    case 3:
                        Assign();
                        break;
                    case 4:
                        Print();
                        break;
                    case 5:
                        PrintAll();
                        break;
                    case 6:
                        break;

                }
            } while (choiceInDigit != 6);
        }
        public void Add()
        {
            string? ans = "yes";
            do
            {
                Console.WriteLine("Enter employee name");
                string? empName = Console.ReadLine();
                Console.WriteLine("Enter your Manager name");
                string? managerName = Console.ReadLine();
                Console.WriteLine("Enter employee's years of experience");
                string? yrsExperienceString = Console.ReadLine();

                HireEmployee(empName, managerName, yrsExperienceString);

                Console.WriteLine("Do you want to add another?");
                ans = Console.ReadLine();
            } while (ans.Equals("yes"));


        }

        private void HireEmployee(string empName, string managerName, string yrsExperienceString)
        {

            IEmployee emp = new Employee();
            emp.Name = empName;
            emp.Manager = managerName;
            emp.YearsOfExperience = int.Parse(yrsExperienceString);
            emp.OnTransferd += TriggerTransferProcess;//new EventHandler(TriggerTransferProcess);            
            emp.Hire((a) => Console.WriteLine(a));
            employees.Add(emp);

            if (!employees.Where(m => m.Name == managerName).Any())
            {
                IEmployee manager = new Manager();
                manager.Name = managerName;
                employees.Add(manager);
            }

            _notifier.EmployeeHired(emp);
        }

        private void Assign()
        {
            IEmployee employee = FindEmployeeByName();
            Console.WriteLine("Enter the Account Code");
            string accountCode = Console.ReadLine();
            employee.AccountCode = accountCode;
        }


        private IEmployee FindEmployeeByName()
        {
            if (!Validate())
                return new NullEmployee();
            //IEmployee.Graduitycalcdeletegate del = ShowGraduity();
            Console.WriteLine("Enter the name of the employee");
            string? name = Console.ReadLine();
            IEmployee? employee = employees.ToList().Where(m => m.Name == name).FirstOrDefault();
            if (employee != null)
                return employee;
            else
                return new NullEmployee();
        }

        private void ShowGraduity(double amount)
        {
            Console.WriteLine(amount);
        }

        private void PrintAll()
        {
            if (!Validate())
                return;
            employees.ForEach(m => m.PrintEmployeeInfo());

        }

        private void Print()
        {
            IEmployee employee = FindEmployeeByName();
            if (employee.Role != Role.None)
                employee.PrintEmployeeInfo();
            else
                Console.WriteLine("Employee with given name not found. Please enter a valid name.");
        }

        public void PrintUsingDelegate(EmployeeDelegate del)
        {
            del();
        }

        private void TriggerTransferProcess(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                if (!Validate())
                    return;
                IEmployee emp = ((IEmployee)sender);
                Console.WriteLine(string.Format("{0} has Transfered.", emp.Name));
                IEmployee manager = employees.Where(m => m.Name == emp.Manager && m.Role == Role.Manager).FirstOrDefault();
                if (manager != null)
                {
                    manager.Messages.Add(string.Format("Manager Notificaton: Your team member {0} has requested for Transfer", emp.Name));
                }

                //OnEmployeeTransfer(emp, new EventArgs());
                _notifier.EmployeeTransferred(emp);




            }
        }
        private void Transfer()
        {
            IEmployee employee = FindEmployeeByName();
            if (employee.Role != Role.None)
                employee.Transfer();
            else
                Console.WriteLine("Employee with given name not found !. Please enter a valid name.");


        }

        public void UpdatePayrollStatus()
        {
            Console.WriteLine("Payroll processing is done");
        }

        private bool Validate()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employee found in the system");
                return false;
            }

            return true;
        }

    }
}