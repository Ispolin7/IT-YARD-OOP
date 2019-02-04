using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace IT_YARD.Common
{
    public class JsonSerializer<T>
    {
        private DataContractJsonSerializer Serializer { get; }
        private string FilePath { get; }

        public JsonSerializer()
        {
            this.Serializer = new DataContractJsonSerializer(typeof(List<T>));
            this.FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\ApplicationData\\" + typeof(T) + ".json";
            
        }

        /// <summary>
        /// Deserialize information from json file to list
        /// </summary>
        /// <returns>entity list or null</returns>
        public List<T> Read()
        {
            using (FileStream stream = new FileStream(this.FilePath, FileMode.OpenOrCreate))
            {
                if (stream.Length != 0)
                {
                    return (List<T>)Serializer.ReadObject(stream);
                }
            }
            return null;
        }

        /// <summary>
        /// Serealize information from list to json file
        /// </summary>
        /// <param name="list"></param>
        /// <returns>true if file update</returns>
        public bool Update(List<T> list)
        {
            using (FileStream stream = new FileStream(this.FilePath, FileMode.Truncate))
            {
                Serializer.WriteObject(stream, list);
                return true;
            }
        }
    }
}
