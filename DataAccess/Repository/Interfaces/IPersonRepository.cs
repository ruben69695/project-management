using System;
using System.Linq;
using System.Collections.Generic;

using Models;
namespace DataAccess.Repository.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetByDni(string dni);
        IList<Person> GetByFullName(string name, string lastName);
        IList<Person> GetByRole(Role role);
        IList<Person> GetByRole(string roleCode);
        IList<Person> GetByCompany(Company company);
        IList<Person> GetByCompany(string companyCif);
        IList<Person> GetByAge(int age);
        IList<Person> GetBySex(Sex sex);
        IList<Person> GetBySex(string sexCode);
    }
}
