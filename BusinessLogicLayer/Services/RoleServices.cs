using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
using Interfaces;
using BusinessLogicLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public class RoleServices:IRoleServices
    {
        RoleJsonOperations roleJson = new RoleJsonOperations();
        private readonly IRoleUI roleValidation;

        public RoleServices(IRoleUI roleValidation)
        {
            this.roleValidation = roleValidation;
        }

        public void AddRole()
        {
            Role r = new Role();
            string roleName = roleValidation.ValidateText("Role Name");
            r.RoleName = roleName;

            string department = roleValidation.ValidateText("Department");
            r.Department = department;

            string description = roleValidation.ValidateText("Description");
            r.Description = description;

            string location = roleValidation.ValidateText("Location");
            r.Location = location;

            List<Role> role = roleJson.LoadExistingJsonFile<Role>("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Roles.json");
            role.Add(r);
            roleJson.SaveObjectsToJson(role, "C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Roles.json");


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee added successfully");
            Console.ResetColor();
        }

        public void DisplayAll()
        {
            //var roles = role.GetRoles();
            List<Role> role = roleJson.LoadExistingJsonFile<Role>("C:\\Users\\lekyasri.c\\Downloads\\TASKS\\Task 5 - EmployeeConsole ClassLibrary\\Data\\Roles.json");

            if (!role.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No roles to display");
                Console.ResetColor();
                return;
            }
            else
            {
                foreach (var r in role)
                {
                    Console.WriteLine("Role Details:");
                    Console.WriteLine($"Role Name: {r.RoleName}");
                    Console.WriteLine($"Department: {r.Department}");
                    Console.WriteLine($"Description: {r.Description}");
                    Console.WriteLine($"Location: {r.Location}");
                    Console.WriteLine("======================================");
                }
            }
        }
    }
}
