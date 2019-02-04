using System;
using System.Linq;
using IT_YARD.Common;
using IT_YARD.Models;
using System.Collections;
using System.Collections.Generic;

namespace IT_YARD.Repositories
{
    /// <summary>
    /// Base entity collection
    /// </summary>
    class RepositoryGeneric<T> : IRepository<T> where T : EntityBase
    {
        //private Logger logger = new Logger();
        private readonly FileLogger logger = new FileLogger();
        public static Dictionary<Guid, T> items = new Dictionary<Guid, T>();

        //private int increment = 1;

        /// <summary>
        /// Convert repository to array and return it
        /// </summary>
        /// <returns>Array of all values</returns>
        public IEnumerable<T> All()
        {
            return items.Values.ToArray();
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
                items.Add(item.Id, item);
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
            if (items.ContainsKey(id))
            {
                items.TryGetValue(id, out currentItem);
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
            if (items.ContainsKey(id))
            {
                this.logger.LogInfo($"Delete {typeof(T).Name} with id - {id}");
                return items.Remove(id);
            }
            this.logger.LogError($"Could not delete {typeof(T).Name} with id - {id}. Not found");
            return false;
            
        }

        /// <summary>
        /// Display Entity information by id
        /// </summary>
        /// <param name="id"></param>
        public void DisplayItemInfo(Guid id)
        {
            T item = this.GetById(id);
            if (item != null)
            {
                Console.Write($"ID - {id}. ");
                item.DisplayEntityInfo();
            }            
        }

        /// <summary>
        /// Update item in repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>true if element update</returns>
        public bool Update(T item)
        {
            if (items.ContainsKey(item.Id) && item.Validate())
            {
                items[item.Id] = item;
                this.logger.LogInfo($"Update {typeof(T).Name} with id - {item.Id}");
                return true;
            }
            this.logger.LogError($"Could not update {typeof(T).Name} with id - {item.Id}");
            return false;
        }
    }
}
