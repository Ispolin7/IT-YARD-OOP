using System;
using System.IO;
using IT_YARD.Common;
using IT_YARD.Models;
using System.Collections.Generic;

namespace IT_YARD.Repositories
{
    class JsonRepositoryGeneric<T> : IRepository<T> where T : EntityBase
    {
        //private Logger Log = new Logger();
        private FileLogger Log { get; }
        private List<T> EntityList { get; set; }
        private JsonSerializer<T> Serializer { get; }

        /// <summary>
        /// Repository constructor
        /// </summary>
        public JsonRepositoryGeneric()
        {
            this.Log = new FileLogger();
            this.EntityList = new List<T>();
            this.Serializer = new JsonSerializer<T>();

            File.Delete(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\ApplicationData\\" + typeof(T) + ".json");
        }

        /// <summary>
        /// Convert repository to array and return it
        /// </summary>
        /// <returns>Array of all values</returns>
        public IEnumerable<T> All()
        {
            this.EntityList = Serializer.Read();
            foreach (T item in EntityList)
            {
                item.AppendRelated();
            }
            return EntityList;
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
                EntityList = this.Serializer.Read();
                if (EntityList == null)
                {
                    EntityList = new List<T>();
                }
                EntityList.Add(item);
                this.Serializer.Update(EntityList);
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
            EntityList = this.Serializer.Read();

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
            EntityList = this.Serializer.Read();
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
            this.Serializer.Update(EntityList);
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
            EntityList = this.Serializer.Read();
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
            this.Serializer.Update(EntityList);
            this.Log.LogInfo($"Update {typeof(T).Name} with id - {item.Id}");
            return true;
        }
    }
}
