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
    public class WorkMethodologyRepositoryTests
    {
        private readonly IWorkMethodologyRepository _repository;
        private WorkMethodology workMethodologyTest;

        public WorkMethodologyRepositoryTests() 
        {
            using(var scope = Container.MainContainer.BeginLifetimeScope())
            {
                _repository = scope.Resolve<IWorkMethodologyRepository>();
            }

            workMethodologyTest = new WorkMethodology
            {
                Code = "SCR",
                Name = "Scrum"
            };
        }

        [TestMethod]
        public void CanGetByCode()
        {
            if(_repository.Create(workMethodologyTest))
            {
                WorkMethodology workMethodologyFinded = _repository.GetByCode(workMethodologyTest.Code);
                Assert.AreEqual(workMethodologyTest, workMethodologyFinded);
            }
            else
            {
                Assert.Fail("Can't create the sex object for test");
            }
        }
    }
}
