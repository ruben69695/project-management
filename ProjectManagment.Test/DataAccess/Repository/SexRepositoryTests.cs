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
    public class SexRepositoryTests
    {
        private readonly ISexRepository _repository;
        private Sex sexTest;

        public SexRepositoryTests() 
        {
            using(var scope = Container.MainContainer.BeginLifetimeScope())
            {
                _repository = scope.Resolve<ISexRepository>();
            }

           sexTest = new Sex
            {
                Code = "U",
                Description = "Unknown"
            };
        }

        [TestMethod]
        public void CanGetByCode()
        {
            if(_repository.Create(sexTest))
            {
                Sex sexFinded = _repository.GetByCode(sexTest.Code);
                Assert.AreEqual(sexTest, sexFinded);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }
    }
}
