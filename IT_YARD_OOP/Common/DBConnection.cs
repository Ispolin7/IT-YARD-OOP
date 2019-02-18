using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IT_YARD.Models;
using Newtonsoft.Json;

namespace IT_YARD.Common
{
    class DBConnection : IBaseConnection
    {
        public string FilePath { get; }
        public Dictionary<string, List<EntityBase>> DB { get; set; }

        public DBConnection()
        {
            FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\ApplicationData\\DB.json";
            File.WriteAllText(FilePath, string.Empty);
            DB = new Dictionary<string, List<EntityBase>>();
        }

        public IEnumerable<T> Read<T>()
        {
            var list = new List<T>();
            if (!DB.ContainsKey(typeof(T).Name))
            {
                DB.Add(typeof(T).Name, list as List<EntityBase>);
                Update(list);
                return list;
            }
            return DB[typeof(T).Name].Cast<T>().ToList();
        }

        public bool Update<T>(IEnumerable<T> newCollection)
        {
            using (StreamWriter writer = new StreamWriter(FilePath, false, Encoding.Default))
            {
                //var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
                DB[typeof(T).Name] = newCollection.Cast<EntityBase>().ToList();
                string serialize = JsonConvert.SerializeObject(DB);
                writer.Write(serialize);
                return true;
            }
        }
    }
}
