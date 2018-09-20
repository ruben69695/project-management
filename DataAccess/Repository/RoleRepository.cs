using System;
using System.Linq;

using Models;
using DataAccess.Repository.Interfaces;
namespace DataAccess.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public Role GetByCode(string code)
        {
            return base.Get().FirstOrDefault((r) => r.Code == code);
        }
    }
}
