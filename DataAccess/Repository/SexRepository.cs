using System;
using System.Linq;

using Models;
using DataAccess.Repository.Interfaces;
namespace DataAccess.Repository
{
    public class SexRepository : Repository<Sex>, ISexRepository
    {
        public Sex GetByCode(string code)
        {
            return base.Get().FirstOrDefault((s) => s.Code == code);
        }
    }
}
