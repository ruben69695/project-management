using System;

using Models;

namespace DataAccess.Repository.Interfaces
{
    public interface ISexRepository : IRepository<Sex>
    {
        Sex GetByCode(string code);
    }
}
