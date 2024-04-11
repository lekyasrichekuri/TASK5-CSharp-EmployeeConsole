using System.Data;
using Interfaces;
using Services;
using UI;
namespace EmployeeConsole
{
    public class EmployeeConsole
    {
        public void Execute()
        {
            IEmployee employeeService = new EmployeeService();
            EmployeeUI employeeUI = new EmployeeUI(employeeService);
            IRole role = new RoleService();
            RoleUI roleUI = new RoleUI(role);
            while (true)
            {
                Console.WriteLine("Select an Option:");
                Console.WriteLine("1.Employee Management");
                Console.WriteLine("2.Role Management");
                Console.WriteLine("3.Exit");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please enter a number.");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        employeeUI.EmployeeManagement();
                        break;
                    case 2:
                        roleUI.RoleManagement();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }
            }
        }
    }
}
