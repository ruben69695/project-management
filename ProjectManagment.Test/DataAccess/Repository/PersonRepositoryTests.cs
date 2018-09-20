using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using Models;
using DependencyResolver;
using DataAccess.Helper;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using Autofac;
using System.Collections.Generic;

namespace ProjectManagment.Test.DataAccess.Helper
{
    [TestClass]
    public class PersonRepositoryTests
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ISexRepository _sexRepository;
        private readonly IRoleRepository _roleRepository;
        private Person personTest;
        private Sex sexTest;
        private Role roleTest;
        private Company companyTest;

        public PersonRepositoryTests() 
        {
            using(var scope = Container.MainContainer.BeginLifetimeScope())
            {
                _personRepository = scope.Resolve<IPersonRepository>();
                _companyRepository = scope.Resolve<ICompanyRepository>();
                _sexRepository = scope.Resolve<ISexRepository>();
                _roleRepository = scope.Resolve<IRoleRepository>();

                sexTest = new Sex { Code = "M", Description = "Male" };
                roleTest = new Role { Code = "JD", Name = "Junior Developer" };
                companyTest = new Company { Cif = "45689976", Name = "Indra" };

                personTest = new Person
                {
                    Dni = "47918130E",
                    Age = 22,
                    FirstName = "Rubén",
                    LastName = "Arrebola de Haro",
                    Sex = sexTest,
                    Role = roleTest,
                    Company = companyTest
                };
            }


        }

        [TestMethod]
        public void CanGetByDni()
        {
            if(CreatePerson())
            {
                Person personFinded = _personRepository.GetByDni(personTest.Dni);
                Assert.AreEqual(personTest, personFinded);   
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }

        [TestMethod]
        public void CanGetUsersByRole()
        {
            if(CreatePerson())
            {
                IList<Person> peopleFound = _personRepository.GetByRole(roleTest);
                Assert.AreEqual(true, peopleFound.Count > 0);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }

        [TestMethod]
        public void CanGetUsersByRoleCode()
        {
            if(CreatePerson())
            {
                IList<Person> peopleFound = _personRepository.GetByRole(roleTest.Code);
                Assert.AreEqual(true, peopleFound.Count > 0);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }

        [TestMethod]
        public void CanGetUsersByAge()
        {
            if (CreatePerson())
            {
                IList<Person> peopleFound = _personRepository.GetByAge(personTest.Age);
                Assert.AreEqual(true, peopleFound.Count > 0);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }

        [TestMethod]
        public void CanGetByCompany()
        {
            if (CreatePerson())
            {
                IList<Person> peopleFound = _personRepository.GetByCompany(personTest.Company);
                Assert.AreEqual(true, peopleFound.Count > 0);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            } 
        }

        [TestMethod]
        public void CanGetByCompanyCif()
        {
            if (CreatePerson())
            {
                IList<Person> peopleFound = _personRepository.GetByCompany(personTest.Company.Cif);
                Assert.AreEqual(true, peopleFound.Count > 0);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }

        [TestMethod]
        public void CanGetBySex()
        {
            if (CreatePerson())
            {
                IList<Person> peopleFound = _personRepository.GetBySex(personTest.Sex);
                Assert.AreEqual(true, peopleFound.Count > 0);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }

        [TestMethod]
        public void CanGetBySexCode()
        {
            if (CreatePerson())
            {
                IList<Person> peopleFound = _personRepository.GetBySex(personTest.Sex.Code);
                Assert.AreEqual(true, peopleFound.Count > 0);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }

        private bool CreatePerson()
        {
            bool created = false;

            _roleRepository.Create(roleTest);
            _sexRepository.Create(sexTest);
            _companyRepository.Create(companyTest);

            if (_personRepository.Create(personTest))
                created = true;

            return created;
        }
    }
}
