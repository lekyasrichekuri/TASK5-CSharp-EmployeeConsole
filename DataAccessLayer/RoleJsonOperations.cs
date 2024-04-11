using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleJsonOperations
    {
        public List<Role> LoadExistingJsonFile<Role>(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);
                return JsonConvert.DeserializeObject<List<Role>>(json) ?? new List<Role>();
            }
            else
            {
                return new List<Role>();
            }
        }
        
        public void SaveObjectsToJson(List<Role> objects, string jsonFilePath)
        {
            string json = JsonConvert.SerializeObject(objects, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
    }
}
