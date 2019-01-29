using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using IT_YARD.Common;
using IT_YARD.Models;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace IT_YARD.Repositories
{
    class JsonRepositoryGeneric<T> where T : EntityBase
    {
        //private Logger logger = new Logger();
        private FileLogger logger = new FileLogger();
        //public static Dictionary<int, T> items = new Dictionary<int, T>();
        DataContractJsonSerializer serializer;
        public List<T> list;
        private string file;

        public JsonRepositoryGeneric()
        {
            this.list = new List<T>();
            this.serializer = new DataContractJsonSerializer(typeof(List<T>));
            this.file = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\ApplicationData\\" + typeof(T) + ".json";
        }
        /// <summary>
        /// Convert repository to array and return it
        /// </summary>
        /// <returns>Array of all values</returns>
        public List<T> All()
        {
            using (FileStream stream = new FileStream(this.file, FileMode.OpenOrCreate))
            {
                return (List<T>)serializer.ReadObject(stream);
            }
        }

        /// <summary>
        /// Add new item in repository
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if item added</returns>
        public bool Insert(T item)
        {
            if (item.Validate())
            {
                using (FileStream stream = new FileStream(this.file, FileMode.Create))
                {
                    if(stream.Length != 0)
                    {
                        list = (List<T>)serializer.ReadObject(stream);
                    }
                    
                    list.Add(item);
                    serializer.WriteObject(stream, list);
                }
                this.logger.LogInfo($"Add {typeof(T).Name} with id - {item.Id} to repository");
                return true;
            }
            this.logger.LogError($"Item not added, validation error");
            return false;
        }

        /// <summary>
        /// Get item by id from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity if it exists in the repository, else - return null</returns>
        public T GetById(Guid id)
        {
            T currentItem = null;
            List<T> items = this.All();
            foreach(T element in items)
            {
                if (element.Id == id)
                {
                    currentItem = element;
                    break;
                }
            }
            return currentItem;
        }

        /// <summary>
        /// Delete item from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if element delete from repository</returns>
        public bool Delete(Guid id)
        {
            //T currentItem = this.GetById(id);
            using (FileStream stream = new FileStream(this.file, FileMode.OpenOrCreate))
            {
                list = (List<T>)serializer.ReadObject(stream);
                foreach (T element in list)
                {
                    if (element.Id == id)
                    {                      
                        list.Remove(element);
                        serializer.WriteObject(stream, list);
                        this.logger.LogInfo($"Delete {typeof(T).Name} with id - {id}");
                        return true;
                    }
                }
            }
            
            this.logger.LogError($"Could not delete {typeof(T).Name} with id - {id}. Not found");
            return false;

        }

        /// <summary>
        /// Display Entity information by id
        /// </summary>
        /// <param name="id"></param>
        //public void DisplayItemInfo(int id)
        //{
        //    T item = this.GetById(id);
        //    if (item != null)
        //    {
        //        Console.Write($"ID - {id}. ");
        //        item.DisplayEntityInfo();
        //    }
        //}

        /// <summary>
        /// Update item in repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>true if element update</returns>
        public bool Update(T item)
        {
            using (FileStream stream = new FileStream(this.file, FileMode.OpenOrCreate))
            {
                list = (List<T>)serializer.ReadObject(stream);
                foreach (T element in list)
                {
                    if (element.Id == item.Id)
                    {
                        list.Remove(element);
                        list.Add(item);
                        serializer.WriteObject(stream, list);
                        this.logger.LogInfo($"Update {typeof(T).Name} with id - {item.Id}");
                        return true;
                    }
                }
            }           
            this.logger.LogError($"Could not delete {typeof(T).Name} with id - {item.Id}. Not found");
            return false;
        }
    }
}
