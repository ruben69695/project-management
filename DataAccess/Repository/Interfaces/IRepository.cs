using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /** MAIN CRUD **/
        bool Create(T item);
        IQueryable<T> Get();
        bool Update(T item);
        bool Delete(T item);
    }
}
