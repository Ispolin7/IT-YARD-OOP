using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IT_YARD.Common;
using IT_YARD.Models;

namespace IT_YARD.Repositories
{
    class BaseRepository : IRepository
    {
        //private Logger logger = new Logger();
        private FileLogger logger = new FileLogger();
        public static Dictionary<Guid, object> items = new Dictionary<Guid, object>();

        /// <summary>
        /// Convert repository to array and return it
        /// </summary>
        /// <returns>Array of all values</returns>
        public object[] All()
        {
            return items.Values.ToArray() as EntityBase[];
            //object[] all = new object[items.Count];
            //items.Values.CopyTo(all, 0);
            //return all;
        }

        /// <summary>
        /// Add new item in repository
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if item added</returns>
        public bool Insert(object item)
        {
            var newItem = item as EntityBase;
            if (newItem.Validate())
            {
                items.Add(newItem.Id, newItem);
                this.logger.LogInfo($"Add new item with id - {newItem.Id} to repository");
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
        public object GetById(Guid id)
        {
            object currentItem = null;
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
                this.logger.LogInfo($"Delete item with id - {id}");
                return items.Remove(id);
            }
            this.logger.LogError($"Could not delete item with id - {id}. Not found");
            return false;

        }

        /// <summary>
        /// Display Entity information by id
        /// </summary>
        /// <param name="id"></param>
        public void DisplayItemInfo(Guid id)
        {
            object item = this.GetById(id);
            if (item != null)
            {
                ((EntityBase)item).DisplayEntityInfo();
            }
        }

        /// <summary>
        /// Update item in repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>true if element update</returns>
        public bool Update(Guid id, object item)
        {
            var newItem = item as EntityBase;
            if (items.ContainsKey(id) && newItem.Validate())
            {
                items[id] = newItem;
                this.logger.LogInfo($"Update item with id - {id}");
                return true;
            }
            this.logger.LogError($"Could not update with id - {id}");
            return false;
        }
    }
}
