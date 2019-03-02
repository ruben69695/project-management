using System;
using System.Collections.Generic;
using Services.Helpers.Interfaces;

namespace Services.Interfaces
{
    public interface IMainService<T> : IErrorNotifier where T : class
    {
        bool Create(T item);
        IEnumerable<T> GetList();
        bool Update(T item);
        bool Delete(T item);
    }
}
