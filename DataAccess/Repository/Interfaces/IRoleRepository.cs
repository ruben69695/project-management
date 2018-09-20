using System;
using System.Linq;

using Models;
namespace DataAccess.Repository.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByCode(string code);
    }
}
