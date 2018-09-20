using System;
using System.Linq;

using Models;
using DataAccess.Repository.Interfaces;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public IList<Person> GetByAge(int age)
        {
            return base.Get().Where((p) => p.Age == age).ToList();
        }

        public IList<Person> GetByCompany(Company company)
        {
            return base.Get().Where((p) => p.Company == company).ToList();
        }

        public IList<Person> GetByCompany(string companyCif)
        {
            return base.Get().Where((p) => p.Company.Cif == companyCif).ToList();
        }

        public Person GetByDni(string dni)
        {
            return base.Get().FirstOrDefault((p) => p.Dni == dni);
        }

        public IList<Person> GetByFullName(string name, string lastName)
        {
            return base.Get().Where((p) => p.FirstName.Contains(name) && p.LastName.Contains(lastName)).ToList();
        }

        public IList<Person> GetByRole(Role role)
        {
            return base.Get().Where((p) => p.Role == role).ToList();
        }

        public IList<Person> GetByRole(string roleCode)
        {
            return base.Get().Where((p) => p.Role.Code == roleCode).ToList();
        }

        public IList<Person> GetBySex(Sex sex)
        {
            return base.Get().Where((p) => p.Sex == sex).ToList();
        }

        public IList<Person> GetBySex(string sexCode)
        {
            return base.Get().Where((p) => p.Sex.Code == sexCode).ToList();
        }
    }
}
