using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Models;


namespace DataAccessLayer
{
    public class EmployeeJsonOperations
    {
        public void SaveObjectsToJson<Employee>(Dictionary<string, Employee> objects, string jsonFilePath)
        {
            string json = JsonConvert.SerializeObject(objects.Values.ToList(), Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }

        public Dictionary<string, Employee> LoadExistingJsonFile(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                var objectsList = JsonConvert.DeserializeObject<List<Employee>>(json) ?? new List<Employee>();
                return objectsList.ToDictionary(obj => obj.EmpId, obj => obj);
            }
            else
            {
                return new Dictionary<string, Employee>();
            }
        }
    }
}
