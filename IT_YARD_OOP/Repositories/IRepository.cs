using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Repositories
{
    interface IRepository
    {
        /// <summary>
        /// Get all objects from repository
        /// </summary>
        /// <returns>array</returns>
        object[] All();

        /// <summary>
        /// Add new item to repository
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if item added</returns>
        bool Insert(object item);

        /// <summary>
        /// Get item object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>item</returns>
        object GetById(Guid id);

        /// <summary>
        /// Delete item from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if item delete</returns>
        bool Delete(Guid id);

        /// <summary>
        /// Display item information
        /// </summary>
        /// <param name="id"></param>
        void DisplayItemInfo(Guid id);

        /// <summary>
        /// Update item information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>true if item updated</returns>
        bool Update(Guid id, object item);
    }
}
