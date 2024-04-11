using Microsoft.Extensions.DependencyInjection;
using EmployeeConsole.PAL.Services;

namespace EmployeeConsole.Main
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                                  .AddTransient<EmployeeUI>()
                                  .AddTransient<RoleUI>()
                                  .BuildServiceProvider();
            while (true)
            {
                Console.WriteLine("Select an Option:");
                Console.WriteLine("1. Employee Management");
                Console.WriteLine("2. Role Management");
                Console.WriteLine("3. Exit");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        var employeeUI = serviceProvider.GetRequiredService<EmployeeUI>();
                        employeeUI.EmployeeManagement();
                        break;
                    case 2:
                        var roleUI = serviceProvider.GetRequiredService<RoleUI>();
                        roleUI.RoleManagement();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a valid option");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}