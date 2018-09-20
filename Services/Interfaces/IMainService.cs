using System;
using System.Collections.Generic;
namespace Services.Interfaces
{
    public interface IMainService<T> where T : class
    {
        bool Create(T item);
        IEnumerable<T> GetList();
        bool Update(T item);
        bool Delete(T item);
    }
}
