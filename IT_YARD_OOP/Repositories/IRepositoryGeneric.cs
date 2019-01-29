using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Repositories
{
    interface IRepository<T>
    {
        T[] All();
        bool Insert(T item);
        T GetById(int id);
        bool Delete(int id);
        void DisplayItemInfo(int id);
        bool Update(int id, T item);        
    }
}
