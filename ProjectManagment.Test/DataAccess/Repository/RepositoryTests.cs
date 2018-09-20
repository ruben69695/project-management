using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using Models;
using DependencyResolver;
using DataAccess.Helper;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using Autofac;
using System.Linq;

namespace ProjectManagment.Test.DataAccess.Helper
{
    [TestClass]
    public class RepositoryTests
    {
        private readonly IRepository<Sex> _repository;
        private Sex sexTest;

        public RepositoryTests() 
        {
            _repository = new Repository<Sex>();

            sexTest = new Sex
            {
                Code = "U",
                Description = "Unknown"
            };
        }
        
        [TestMethod]
        public void CanAddNewItem()
        {
            bool result = _repository.Create(sexTest);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CanUpdateExistingItem()
        {
            sexTest.Description = "Unknown";
            bool result = _repository.Update(sexTest);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CanGetList()
        {
            _repository.Create(sexTest);
            Sex result = _repository.Get().Where(s => s.Code == "U").FirstOrDefault();
            Assert.AreEqual(sexTest, result);
        }

        [TestMethod]
        public void CanDeleteItem()
        {
            _repository.Create(sexTest);
            bool deleted = _repository.Delete(sexTest);
            Assert.AreEqual(deleted, true);
        }


    }
}
