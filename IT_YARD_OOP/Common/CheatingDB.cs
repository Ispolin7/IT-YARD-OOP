using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IT_YARD.Models;
using Newtonsoft.Json;

namespace IT_YARD.Common
{
    public static class CheatingDB
    {
        public static string FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\ApplicationData\\DB.json";
        public static Dictionary<string, List<EntityBase>> db;

        static CheatingDB()
        {
            File.WriteAllText(FilePath, string.Empty);
            using (StreamReader reader = new StreamReader(FilePath, Encoding.Default))
            {
                db = JsonConvert.DeserializeObject<Dictionary<string, List<EntityBase>>>(reader.ReadToEnd());
                if (db == null)
                {
                    db = new Dictionary<string, List<EntityBase>>();
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ReadDB<T>()
        {
            var list = new List<T>();
            if (!db.ContainsKey(typeof(T).Name))
            {
                db.Add(typeof(T).Name, list as List<EntityBase>);
                UpdateDB(list);
                return list;
            }
            return db[typeof(T).Name].Cast<T>().ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newInformation"></param>
        /// <returns></returns>
        public static bool UpdateDB<T>(List<T> newInformation)
        {
            using (StreamWriter writer = new StreamWriter(FilePath, false, Encoding.Default))
            {
                db[typeof(T).Name] = newInformation.Cast<EntityBase>().ToList();
                string serialize = JsonConvert.SerializeObject(db);
                writer.Write(serialize);
                return true;
            }
        }
    }
}
