using System;
using ConnectionStringHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringHelperTests
{
    [TestClass]
    public class ConnectionStringTests
    {
        [TestMethod]
        public void SQLDataSourceConnectionString()
        {
            var x=ConnectionString.GetSqlDataSourceConnectionString(".");
            Assert.AreEqual(x, "Data Source=.;Integrated Security=True");

            var y = ConnectionString.GetSqlServerConnectionString(".", "dbName");
            Assert.AreEqual(y, "Data Source=.;Initial Catalog=dbName;Integrated Security=True");
        }
    }
}
