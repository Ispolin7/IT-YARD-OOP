using System;
using System.IO;
using IT_YARD.Common;
using IT_YARD.Models;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace IT_YARD.Repositories
{
    class JsonRepositoryGeneric<T> /*: IRepository<T>*/ where T : EntityBase
    {
        //private Logger Log = new Logger();
        private FileLogger Log { get; }
        private DataContractJsonSerializer Serializer { get; }
        private List<T> EntityList { get; set; }
        //private List<T> EmptyList { get; }
        private string FilePath { get; }

        /// <summary>
        /// Repository constructor
        /// </summary>
        public JsonRepositoryGeneric()
        {
            this.Log = new FileLogger();
            this.EntityList = new List<T>();
            //this.EmptyList = new List<T>();
            this.Serializer = new DataContractJsonSerializer(typeof(List<T>));
            this.FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\ApplicationData\\" + typeof(T) + ".json";
            //File.Create(this.FilePath);
        }
        /// <summary>
        /// Convert repository to array and return it
        /// </summary>
        /// <returns>Array of all values</returns>
        public List<T> All()
        {
            return ReadJson();
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
                EntityList = ReadJson();
                if (EntityList == null)
                {
                    EntityList = new List<T>();
                }
                EntityList.Add(item);
                UpdateJson(EntityList);
                this.Log.LogInfo($"Add {typeof(T).Name} with id - {item.Id} to repository");
                return true;
                                
            }
            this.Log.LogError($"{typeof(T).Name} not added, validation error");
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
            EntityList = ReadJson();

            if (EntityList == null)
            {
                return currentItem;
            }

            foreach (T element in EntityList)
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
            EntityList = ReadJson();
            if (EntityList == null)
            {
                this.Log.LogError($"Could not delete {typeof(T).Name} with id - {id}. Not found");
                return false;
            }
            foreach (T element in EntityList)
            {
                if (element.Id == id)
                {
                    EntityList.Remove(element);
                    break;
                }
            }
            UpdateJson(EntityList);
            this.Log.LogInfo($"Delete {typeof(T).Name} with id - {id}");
            return true;
        }

        /// <summary>
        /// Update item in repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>true if element update</returns>
        public bool Update(T item)
        {
            EntityList = ReadJson();
            if (EntityList == null)
            {
                return false;
            }
            foreach (T element in EntityList)
            {
                if (element.Id == item.Id)
                {
                    EntityList.Remove(element);
                    EntityList.Add(item);
                    break;
                }
            }
            UpdateJson(EntityList);
            this.Log.LogInfo($"Update {typeof(T).Name} with id - {item.Id}");
            return true;
        }

        /// <summary>
        /// Deserialize information from json file to list
        /// </summary>
        /// <returns>entity list or null</returns>
        public List<T> ReadJson()
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
        public bool UpdateJson(List<T> list)
        {
            using (FileStream stream = new FileStream(this.FilePath, FileMode.Truncate))
            {
                Serializer.WriteObject(stream, list);
                return true;
            }
        }
    }
}
