using System;
using System.Linq;
using IT_YARD.Common;
using IT_YARD.Models;
using System.Collections.Generic;

namespace IT_YARD.Repositories
{
    /// <summary>
    /// Base entity collection
    /// </summary>
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public Dictionary<Guid, T> Items { get; set; }

        public Repository()
        {
            Items = new Dictionary<Guid, T>();
        }

        /// <summary>
        /// Convert repository to array and return it
        /// </summary>
        /// <returns>Array of all values</returns>
        public IEnumerable<T> All()
        {
            return Items.Values.ToList();
        }

        /// <summary>
        /// Add new item in repository
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if item added</returns>
        public bool Insert(T item)
        {           
            Items.Add(item.Id, item);
            Logger.LogInfo($"Add {typeof(T).Name} with id - {item.Id} to repository");
            return true;
        }

        /// <summary>
        /// Get item by id from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity if it exists in the repository, else - return null</returns>
        public T GetById(Guid id)
        {         
            return Items[id];          
        }

        /// <summary>
        /// Update item in repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>true if element update</returns>
        public bool Update(T item)
        {
            Items[item.Id] = item;
            Logger.LogInfo($"Update {typeof(T).Name} with id - {item.Id}");
            return true;
        }

        /// <summary>
        /// Delete item from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if element delete from repository</returns>
        public bool Delete(Guid id)
        {         
            Logger.LogInfo($"Delete {typeof(T).Name} with id - {id}");
            return Items.Remove(id);            
        }

        /// <summary>
        /// Check if there is an entity with such an id in the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if find</returns>
        public bool InRepository(Guid id)
        {
            return Items.ContainsKey(id);
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
    }
}
