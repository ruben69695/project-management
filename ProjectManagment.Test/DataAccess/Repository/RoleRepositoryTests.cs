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
    public class RoleRepositoryTests
    {
        private readonly IRoleRepository _repository;
        private Role roleTest;

        public RoleRepositoryTests() 
        {
            using(var scope = Container.MainContainer.BeginLifetimeScope())
            {
                _repository = scope.Resolve<IRoleRepository>();
            }

            roleTest = new Role
            {
                Code = "UKN",
                Name = "Unknown"
            };
        }

        [TestMethod]
        public void CanGetByCode()
        {
            if(_repository.Create(roleTest))
            {
                Role roleFinded = _repository.GetByCode(roleTest.Code);
                Assert.AreEqual(roleTest, roleFinded);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }
    }
}
