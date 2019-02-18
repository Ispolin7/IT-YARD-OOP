using IT_YARD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Common
{
    public interface IBaseConnection
    {
        string FilePath { get; }
        Dictionary<string, List<EntityBase>> DB { get; set; }
        IEnumerable<T> Read<T>();
        bool Update<T>(IEnumerable<T> collection);
    }
}
