using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EmployeeConsole.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using EmployeeConsole.DAL;
using EmployeeConsole.BLL.Services;
using Interfaces;


namespace EmployeeConsole.PAL.Services
{
    public class RoleUI : IRoleUI
    {
        //public readonly IRole role;
        //public RoleUI(IRole r)
        //{
        //    role = r;
        //}
        RoleJsonOperations roleJson = new RoleJsonOperations();
        public void RoleManagement()
        {
            //IRole ir = new RoleService();
            //RoleUI roleUi = new RoleUI(ir);
            IRoleUI roleui = new RoleUI();
            RoleServices services = new RoleServices(roleui);
            bool isValid = true;
            while (isValid)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Role");
                Console.WriteLine("2. Display All");
                Console.WriteLine("3. Go Back");
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
                        services.AddRole();
                        break;
                    case 2:
                        services.DisplayAll();
                        break;
                    case 3:
                        isValid = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a valid option");
                        Console.ResetColor();
                        break;
                }
            }
        }

        //public void AddRole()
        //{
        //    Role r = new Role();
        //    string roleName = ValidateText("Role Name");
        //    r.RoleName = roleName;

        //    string department = ValidateText("Department");
        //    r.Department = department;

        //    string description = ValidateText("Description");
        //    r.Description = description;

        //    string location = ValidateText("Location");
        //    r.Location = location;

        //    List<Role> role = roleJson.LoadExistingJsonFile<Role>("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Roles.json");
        //    role.Add(r);
        //    roleJson.SaveObjectsToJson(role, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Roles.json");


        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("Employee added successfully");
        //    Console.ResetColor();
        //}

        //public void DisplayAll()
        //{
        //    //var roles = role.GetRoles();
        //    List<Role> role = roleJson.LoadExistingJsonFile<Role>("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Roles.json");

        //    if (!role.Any())
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("No roles to display");
        //        Console.ResetColor();
        //        return;
        //    }
        //    else
        //    {
        //        foreach (var r in role)
        //        {
        //            Console.WriteLine("Role Details:");
        //            Console.WriteLine($"Role Name: {r.RoleName}");
        //            Console.WriteLine($"Department: {r.Department}");
        //            Console.WriteLine($"Description: {r.Description}");
        //            Console.WriteLine($"Location: {r.Location}");
        //            Console.WriteLine("======================================");
        //        }
        //    }
        //}

        public string ValidateText(string type)
        {
            string text = "";
            bool isValidText = false;
            while (!isValidText)
            {
                Console.WriteLine($"Enter {type}:");
                text = Console.ReadLine() ?? "";
                string pattern = @"^[A-Za-z\s]+$";
                //var rolesList = role.GetRoles();
                List<Role> rolesList = roleJson.LoadExistingJsonFile<Role>("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Roles.json");

                var roleNames = rolesList.Select(r => r.RoleName);
                if (type == "Role Name" && roleNames.Contains(text))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Role already exists");
                    Console.ResetColor();
                }
                else if (type == "Description" && string.IsNullOrEmpty(text))
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
    }

}
