using IT_YARD.Common;
using IT_YARD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace IT_YARD.Repositories
{
    class CheatingRepository<T> : IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Entity DB cash
        /// </summary>
        public List<T> DBСache { get; set; }

        /// <summary>
        /// Convert repository to array and return it
        /// </summary>
        /// <returns>Array of all values</returns>
        public IEnumerable<T> All()
        {
            DBСache = CheatingDB.ReadDB<T>();
            foreach (T item in DBСache)
            {
                item.AppendRelated();
            }
            return DBСache;
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
                DBСache = CheatingDB.ReadDB<T>();
                if (DBСache == null)
                {
                    DBСache = new List<T>();
                }
                DBСache.Add(item);
                CheatingDB.UpdateDB(DBСache);

                return true;
            }

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
            DBСache = CheatingDB.ReadDB<T>();

            if (DBСache == null)
            {
                return currentItem;
            }

            foreach (T element in DBСache)
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
            DBСache = CheatingDB.ReadDB<T>();
            if (DBСache == null)
            {
                return false;
            }
            foreach (T element in DBСache)
            {
                if (element.Id == id)
                {
                    DBСache.Remove(element);
                    break;
                }
            }
            CheatingDB.UpdateDB(DBСache);

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
            DBСache = CheatingDB.ReadDB<T>();
            if (DBСache == null)
            {
                return false;
            }

            foreach (T element in DBСache)
            {
                if (element.Id == item.Id)
                {
                    DBСache.Remove(element);
                    DBСache.Add(item);
                    break;
                }
            }
            CheatingDB.UpdateDB(DBСache);
            return true;
        }
    }
}
