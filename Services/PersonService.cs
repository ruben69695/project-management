using System;
using System.Collections.Generic;
using DataAccess.Repository.Interfaces;
using Models;
using Services.Helpers;
using Services.Interfaces;
using System.Linq;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _dataAccess;

        public PersonService(IPersonRepository repository)
        {
            _dataAccess = repository;
        }

        public event EventHandler<ServiceError> NotifyError;

        public bool Create(Person item)
        {
            if (item == null)
                throw new InvalidOperationException("The person to create can't be null");

            return _dataAccess.Create(item);
        }

        public bool Delete(Person item)
        {
            if (item == null)
                throw new InvalidOperationException("The person to delete can't be null");

            return _dataAccess.Delete(item);
        }

        public IList<Person> GetByAge(int age)
        {
            return _dataAccess.GetByAge(age);
        }

        public IList<Person> GetByCompany(Company company)
        {
            if (company == null)
                throw new InvalidOperationException("The company can't be null");

            return _dataAccess.GetByCompany(company);
        }

        public IList<Person> GetByCompany(string companyCif)
        {
            if (string.IsNullOrWhiteSpace(companyCif))
                throw new InvalidOperationException("The company cif can't be null or empty");

            return _dataAccess.GetByCompany(companyCif);
        }

        public Person GetByDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new InvalidOperationException("The dni can't be null or empty");

            return _dataAccess.GetByDni(dni);
        }

        public IList<Person> GetByFullName(string name, string lastName)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("The name can't be null or empty");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new InvalidOperationException("The lastname can't be null or empty");

            return _dataAccess.GetByFullName(name, lastName);
        }

        public IList<Person> GetByRole(Role role)
        {
            if (role == null)
                throw new InvalidOperationException("The role can't be null");

            return _dataAccess.GetByRole(role);
        }

        public IList<Person> GetByRole(string roleCode)
        {
            if (string.IsNullOrWhiteSpace(roleCode))
                throw new InvalidOperationException("The role code can't be null or empty");

            return _dataAccess.GetByRole(roleCode);
        }

        public IList<Person> GetBySex(Sex sex)
        {
            if (sex == null)
                throw new InvalidOperationException("The sex can't be null");

            return _dataAccess.GetBySex(sex);
        }

        public IList<Person> GetBySex(string sexCode)
        {
            if (string.IsNullOrWhiteSpace(sexCode))
                throw new InvalidOperationException("The sexCode can't be null");

            return _dataAccess.GetBySex(sexCode);
        }

        public IEnumerable<Person> GetList()
        {
            return _dataAccess.Get().ToArray();
        }

        public bool Update(Person item)
        {
            if (item == null)
                throw new InvalidOperationException("The person item can't be null");

            return _dataAccess.Update(item);
        }
    }
}
