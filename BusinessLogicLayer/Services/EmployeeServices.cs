using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EmployeeConsole.DAL;
using EmployeeConsole.Models;
using Interfaces;
using EmployeeConsole.BLL.Interfaces;

namespace EmployeeConsole.BLL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        EmployeeJsonOperations EmployeeJson = new EmployeeJsonOperations();
        private readonly IEmployeeUI employeeValidation;

        public EmployeeServices(IEmployeeUI employeeValidation)
        {
            this.employeeValidation = employeeValidation;
        }
        public void DisplayEmployees()
        {
            Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");

            if (!employee.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No employees to display");
                Console.ResetColor();
                return;
            }
            foreach (var e in employee)
            {
                Console.WriteLine("Employee Details:");
                Console.WriteLine($"Employee Id: {e.Key}");
                Console.WriteLine($"Full Name: {e.Value.Name}");
                Console.WriteLine($"Role: {e.Value.JobTitle}");
                Console.WriteLine($"Department: {e.Value.Department}");
                Console.WriteLine($"Location: {e.Value.Location}");
                Console.WriteLine($"Joining Date: {e.Value.JoiningDate}");
                Console.WriteLine($"Manager Name: {e.Value.Manager}");
                Console.WriteLine($"Project Name: {e.Value.Project}");
                Console.WriteLine("======================================");
            }
        }

        public void AddEmployee()
        {
            Employee emp = new Employee();
            string empId = employeeValidation.ValidateEmployeeId();
            emp.EmpId = empId;

            string fname = employeeValidation.ValidateText("First Name");
            string lname = employeeValidation.ValidateText("Last Name");
            emp.Name = fname + " " + lname;

            DateTime dob = employeeValidation.ValidateDate("Birth");
            emp.DateOfBirth = dob.ToShortDateString();

            string email = employeeValidation.ValidateEmail();
            emp.Email = email;

            string phoneNumber = employeeValidation.ValidatePhoneNumber();
            emp.PhoneNumber = phoneNumber;

            DateTime joinDate = employeeValidation.ValidateDate("Joining");
            emp.JoiningDate = joinDate.ToShortDateString();

            string location = employeeValidation.ValidateText("Location");
            emp.Location = location;

            string jobTitle = employeeValidation.ValidateText("Job Title");
            emp.JobTitle = jobTitle;

            string department = employeeValidation.ValidateText("Department");
            emp.Department = department;

            string manager = employeeValidation.ValidateText("Manager");
            emp.Manager = manager;

            string project = employeeValidation.ValidateText("Project");
            emp.Project = project;


            Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
            employee.Add(emp.EmpId, emp);
            EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee added successfully");
            Console.ResetColor();
        }

        public void UpdateEmployee()
        {
            Console.WriteLine("Enter the employee id to be updated:");
            string empid = Console.ReadLine() ?? "";
            Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
            if (!employee.ContainsKey(empid))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee id does not exists");
                Console.ResetColor();
                return;
            }
            Employee emp = employee[empid];
            bool toUpdate = true;
            while (toUpdate)
            {
                Console.WriteLine("Enter the option of the field to be updated:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Email");
                Console.WriteLine("3. Phone number");
                Console.WriteLine("4. Location");
                Console.WriteLine("5. Job Title");
                Console.WriteLine("6. Department");
                Console.WriteLine("7. Manager");
                Console.WriteLine("8. Project");
                Console.WriteLine("9. Go Back");
                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please enter a number.");
                    Console.ResetColor();
                    continue;
                }
                switch (option)
                {
                    case 1:
                        emp.Name = employeeValidation.ValidateText("Name");
                        EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
                        break;
                    case 2:
                        emp.Email = employeeValidation.ValidateEmail();
                        EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
                        break;
                    case 3:
                        emp.PhoneNumber = employeeValidation.ValidatePhoneNumber();
                        EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
                        break;
                    case 4:
                        emp.Location = employeeValidation.ValidateText("Location");
                        EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
                        break;
                    case 5:
                        emp.JobTitle = employeeValidation.ValidateText("Job Title");
                        EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
                        break;
                    case 6:
                        emp.Department = employeeValidation.ValidateText("Department");
                        EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
                        break;
                    case 7:
                        emp.Manager = employeeValidation.ValidateText("Manager");
                        EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
                        break;
                    case 8:
                        emp.Project = employeeValidation.ValidateText("Project");
                        EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
                        break;
                    case 9:
                        toUpdate = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter the correct option");
                        Console.ResetColor();
                        break;
                }
                //employ.UpdateEmployee(empid, emp);
                if (option != 9)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Employee details updated successfully");
                    Console.ResetColor();
                }
            }
        }

        public void DisplayEmpDetails()
        {
            Console.WriteLine("Enter Employee ID to view details:");
            string empId = Console.ReadLine() ?? "";
            Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");

            //var employees = employ.GetEmployees();
            if (!employee.ContainsKey(empId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee Id does not exist");
                Console.ResetColor();
                return;
            }
            Employee emp = employee[empId];
            Console.WriteLine("Employee Details:");
            PropertyInfo[] properties = typeof(Employee).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(emp)}");
            }
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee ID to delete:");
            string empId = Console.ReadLine() ?? "";

            Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
            if (!employee.ContainsKey(empId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Employee Id does not exist");
                Console.ResetColor();
                return;
            }
            employee.Remove(empId);
            EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee deleted successfully");
            Console.ResetColor();
        }
    }
}
