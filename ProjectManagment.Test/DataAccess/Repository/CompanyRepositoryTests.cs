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
    public class CompanyRepositoryTests
    {
        private readonly ICompanyRepository _repository;
        private Company companyTest;

        public CompanyRepositoryTests() 
        {
            using(var scope = Container.MainContainer.BeginLifetimeScope())
            {
                _repository = scope.Resolve<ICompanyRepository>();
            }

           companyTest = new Company
            {
                Name = "Company 1",
                Cif = "7868920N"
            };
        }

        [TestMethod]
        public void CanGetCompanyByCif()
        {
            if (_repository.Create(companyTest))
            {
                Company companyFound = _repository.GetByCif(companyTest.Cif);
                Assert.AreEqual(companyTest, companyFound);
            }
            else
            {
                Assert.Fail("Can't create the company test");
            }
        }

        [TestMethod]
        public void CanGetCompanyByName()
        {
            if(_repository.Create(companyTest))
            {
                IList<Company> companiesFinded = _repository.GetByName(companyTest.Name);
                Assert.AreEqual(companiesFinded.Count > 0, true);
            }
            else
            {
                Assert.Fail("Can't create the company test");
            }
        }
    }
}
