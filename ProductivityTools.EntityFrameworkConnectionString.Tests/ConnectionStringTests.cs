using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductivityToolsTests
{
    [TestClass]
    public class ConnectionStringTests
    {
        [TestMethod]
        public void SQLDataSourceConnectionString()
        {
            var x = ProductivityTools.ConnectionString.GetSqlDataSourceConnectionString(".");
            Assert.AreEqual(x, "Data Source=.;Integrated Security=True");

            var y = ProductivityTools.ConnectionString.GetSqlServerConnectionString(".", "dbName");
            Assert.AreEqual(y, "Data Source=.;Initial Catalog=dbName;Integrated Security=True");
        }

        [TestMethod]
        public void T1()
        {
            Assert.IsTrue(true);
        }
    }
}
