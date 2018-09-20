using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using Models;
using DataAccess.Helper;

namespace ProjectManagment.Test.DataAccess.Helper
{
    [TestClass]
    public class HelperTests
    {
        private ISession _session;

        [TestMethod]
        public void CanCreateDatabaseAndOpenSession()
        {
            bool builded = false;

            _session = NhibernateHelper.OpenSession();

            if (_session != null)
                builded = true;

            Assert.AreEqual(true, builded);
        }
    }
}
