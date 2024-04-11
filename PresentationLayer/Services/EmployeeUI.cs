using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using EmployeeConsole.Models;
using EmployeeConsole.DAL;
using Interfaces;
using EmployeeConsole.BLL.Services;

namespace EmployeeConsole.PAL.Services
{
    public class EmployeeUI : IEmployeeUI
    {
        EmployeeJsonOperations EmployeeJson = new EmployeeJsonOperations();

        public void EmployeeManagement()
        {
            IEmployeeUI empui = new EmployeeUI();
            EmployeeServices services = new EmployeeServices(empui);
            bool isValid = true;
            while (isValid)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Display one employee");
                Console.WriteLine("4. Edit Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Go Back");
                int empOption;
                if (!int.TryParse(Console.ReadLine(), out empOption))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please enter a number.");
                    Console.ResetColor();
                    continue;
                }
                switch (empOption)
                {
                    case 1:
                        services.AddEmployee();
                        break;
                    case 2:
                        services.DisplayEmployees();
                        break;
                    case 3:
                        services.DisplayEmpDetails();
                        break;
                    case 4:
                        services.UpdateEmployee();
                        break;
                    case 5:
                        services.DeleteEmployee();
                        break;
                    case 6:
                        isValid = false;
                        break;
                    default:
                        Console.WriteLine("Enter a Valid Option");
                        break;
                }
            }
        }

        //public void DisplayEmployees()
        //{
        //    //var employees = employ.GetEmployees();

        //    Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");

        //    if (!employee.Any())
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("No employees to display");
        //        Console.ResetColor();
        //        return;
        //    }
        //    foreach (var e in employee)
        //    {
        //        Console.WriteLine("Employee Details:");
        //        Console.WriteLine($"Employee Id: {e.Key}");
        //        Console.WriteLine($"Full Name: {e.Value.Name}");
        //        Console.WriteLine($"Role: {e.Value.JobTitle}");
        //        Console.WriteLine($"Department: {e.Value.Department}");
        //        Console.WriteLine($"Location: {e.Value.Location}");
        //        Console.WriteLine($"Joining Date: {e.Value.JoiningDate}");
        //        Console.WriteLine($"Manager Name: {e.Value.Manager}");
        //        Console.WriteLine($"Project Name: {e.Value.Project}");
        //        Console.WriteLine("======================================");
        //    }
        //}
        //public void AddEmployee()
        //{
        //    Employee emp = new Employee();
        //    string empId = ValidateEmployeeId();
        //    emp.EmpId = empId;

        //    string fname = ValidateText("First Name");
        //    string lname = ValidateText("Last Name");
        //    emp.Name = fname + " " + lname;

        //    DateTime dob = ValidateDate("Birth");
        //    emp.DateOfBirth = dob.ToShortDateString();

        //    string email = ValidateEmail();
        //    emp.Email = email;

        //    string phoneNumber = ValidatePhoneNumber();
        //    emp.PhoneNumber = phoneNumber;

        //    DateTime joinDate = ValidateDate("Joining");
        //    emp.JoiningDate = joinDate.ToShortDateString();

        //    string location = ValidateText("Location");
        //    emp.Location = location;

        //    string jobTitle = ValidateText("Job Title");
        //    emp.JobTitle = jobTitle;

        //    string department = ValidateText("Department");
        //    emp.Department = department;

        //    string manager = ValidateText("Manager");
        //    emp.Manager = manager;

        //    string project = ValidateText("Project");
        //    emp.Project = project;


        //    Dictionary<string,Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //    employee.Add(emp.EmpId, emp);
        //    EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");

        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("Employee added successfully");
        //    Console.ResetColor();
        //}

        //public void UpdateEmployee()
        //{
        //    Console.WriteLine("Enter the employee id to be updated:");
        //    string empid = Console.ReadLine() ?? "";
        //    Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //    if (!employee.ContainsKey(empid))
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Employee id does not exists");
        //        Console.ResetColor();
        //        return;
        //    }
        //    Employee emp = employee[empid];
        //    bool toUpdate = true;
        //    while (toUpdate)
        //    {
        //        Console.WriteLine("Enter the option of the field to be updated:");
        //        Console.WriteLine("1. Name");
        //        Console.WriteLine("2. Email");
        //        Console.WriteLine("3. Phone number");
        //        Console.WriteLine("4. Location");
        //        Console.WriteLine("5. Job Title");
        //        Console.WriteLine("6. Department");
        //        Console.WriteLine("7. Manager");
        //        Console.WriteLine("8. Project");
        //        Console.WriteLine("9. Go Back");
        //        int option;
        //        if (!int.TryParse(Console.ReadLine(), out option))
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Invalid option. Please enter a number.");
        //            Console.ResetColor();
        //            continue;
        //        }
        //        switch (option)
        //        {
        //            case 1:
        //                emp.Name = ValidateText("Name");
        //                EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //                break;
        //            case 2:
        //                emp.Email = ValidateEmail();
        //                EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //                break;
        //            case 3:
        //                emp.PhoneNumber = ValidatePhoneNumber();
        //                EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //                break;
        //            case 4:
        //                emp.Location = ValidateText("Location");
        //                EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //                break;
        //            case 5:
        //                emp.JobTitle = ValidateText("Job Title");
        //                EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //                break;
        //            case 6:
        //                emp.Department = ValidateText("Department");
        //                EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //                break;
        //            case 7:
        //                emp.Manager = ValidateText("Manager");
        //                EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //                break;
        //            case 8:
        //                emp.Project = ValidateText("Project");
        //                EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //                break;
        //            case 9:
        //                toUpdate = false;
        //                break;
        //            default:
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.WriteLine("Enter the correct option");
        //                Console.ResetColor();
        //                break;
        //        }
        //        //employ.UpdateEmployee(empid, emp);
        //        if(option!=9)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            Console.WriteLine("Employee details updated successfully");
        //            Console.ResetColor();
        //        }
        //    }
        //}

        //public void DisplayEmpDetails()
        //{
        //    Console.WriteLine("Enter Employee ID to view details:");
        //    string empId = Console.ReadLine() ?? "";
        //    Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");

        //    //var employees = employ.GetEmployees();
        //    if (!employee.ContainsKey(empId))   
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Employee Id does not exist");
        //        Console.ResetColor();
        //        return;
        //    }
        //    Employee emp = employee[empId];
        //    Console.WriteLine("Employee Details:");
        //    PropertyInfo[] properties = typeof(Employee).GetProperties();
        //    foreach (PropertyInfo property in properties)
        //    {
        //        Console.WriteLine($"{property.Name}: {property.GetValue(emp)}");
        //    }
        //}

        //public void DeleteEmployee()
        //{
        //    Console.WriteLine("Enter Employee ID to delete:");
        //    string empId = Console.ReadLine() ?? "";

        //    Dictionary<string, Employee> employee = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //    if (!employee.ContainsKey(empId))
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Employee Id does not exist");
        //        Console.ResetColor();
        //        return;
        //    }
        //    employee.Remove(empId);
        //    EmployeeJson.SaveObjectsToJson(employee, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("Employee deleted successfully");
        //    Console.ResetColor();
        //}

        public string ValidateEmployeeId()
        {
            string empId = "";
            bool isValidEmpId = false;
            while (!isValidEmpId)
            {
                Console.WriteLine("Enter Employee Id in the format(TZ0001):");
                empId = Console.ReadLine() ?? "";
                string pattern = @"TZ\d{4}$";
                Dictionary<string, Employee> employees = EmployeeJson.LoadExistingJsonFile("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Employees.json");

                //var employees = employ.GetEmployees();

                if (empId == "TZ0000")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Employee ID is not valid");
                    Console.ResetColor();
                }
                else if (employees.ContainsKey(empId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Employee Id already exists");
                    Console.ResetColor();
                }
                else if (Regex.IsMatch(empId, pattern))
                {
                    isValidEmpId = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Enter a valid Employee id in the format TZ0001:");
                    Console.ResetColor();
                }
            }
            return empId;
        }

        public string ValidateText(string type)
        {
            string text = "";
            bool isValidText = false;
            while (!isValidText)
            {
                Console.WriteLine($"Enter Employee {type}:");
                text = Console.ReadLine() ?? "";
                string pattern = @"^[A-Za-z\s]+$";
                if (type == "Manager" && string.IsNullOrEmpty(text) || type == "Project" && string.IsNullOrEmpty(text))
                {
                    isValidText = true;
                }
                else if (Regex.IsMatch(text, pattern))
                {
                    isValidText = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Enter a valid {type} containing only letters.");
                    Console.ResetColor();
                }
            }
            return text;
        }

        public DateTime ValidateDate(string type)
        {
            DateTime date;
            while (true)
            {
                Console.WriteLine($"Enter {type} Date in the format DD-MM-YYYY:");
                string input = Console.ReadLine() ?? "";
                if (type == "Birth" && string.IsNullOrWhiteSpace(input))
                {
                    return DateTime.MinValue;
                }
                else if (DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter date in the format DD-MM-YYYY.");
                    Console.ResetColor();
                }
            }
        }

        public string ValidateEmail()
        {
            string email;
            while (true)
            {
                Console.WriteLine("Enter Email:");
                email = Console.ReadLine() ?? "";
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!string.IsNullOrEmpty(email) && Regex.IsMatch(email, pattern))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter valid email id:");
                    Console.ResetColor();
                }
            }
            return email;
        }

        public string ValidatePhoneNumber()
        {
            string phno = "";
            bool isValidPhoneNumber = false;
            while (!isValidPhoneNumber)
            {
                Console.WriteLine("Enter PhoneNumber:");
                phno = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(phno))
                {
                    isValidPhoneNumber = true;
                }
                else if (string.IsNullOrEmpty(phno) || phno.Length != 10 || !IsNumeric(phno))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter a valid 10-digit PhoneNumber containing only digits.");
                    Console.ResetColor();
                }
                else
                {
                    isValidPhoneNumber = true;
                }
            }
            return phno;
        }

        public static bool IsNumeric(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }

}
