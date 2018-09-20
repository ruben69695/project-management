using System;
using System.Linq;
using System.Collections.Generic;
using DataAccess.Repository.Interfaces;
using DataAccess.Helper;
using NHibernate;
namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ISession _session;

        public Repository() 
        {
            _session = NhibernateHelper.OpenSession();
        }

        /// <summary>
        /// Create the specified item.
        /// </summary>
        /// <returns>If is created</returns>
        /// <param name="item">Item.</param>
        public bool Create(T item)
        {
            return SaveOrUpdate(item);
        }

        /// <summary>
        /// Delete the specified item.
        /// </summary>
        /// <returns>If it's deleted or not</returns>
        /// <param name="item">Item.</param>
        public bool Delete(T item)
        {
            bool deleted = false;
            using(ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(item);
                transaction.Commit();
                deleted = true;
            }
            return deleted;
        }

        /// <summary>
        /// Get an IQueryable of the instance
        /// </summary>
        /// <returns>The get.</returns>
        public IQueryable<T> Get()
        {
            return _session.Query<T>();
        }

        /// <summary>
        /// Update the specified item.
        /// </summary>
        /// <returns>If it's updated or not</returns>
        /// <param name="item">Item.</param>
        public bool Update(T item)
        {
            return SaveOrUpdate(item);
        }

        /// <summary>
        /// Saves the item and if not exists and if exists update the item
        /// </summary>
        /// <returns><c>true</c>, if or update was saved, <c>false</c> otherwise.</returns>
        /// <param name="item">Item to save or update</param>
        private bool SaveOrUpdate(T item)
        {
            bool result = false;
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(item);
                result = true;
                transaction.Commit();
            }
            return result;
        }
    }
}
