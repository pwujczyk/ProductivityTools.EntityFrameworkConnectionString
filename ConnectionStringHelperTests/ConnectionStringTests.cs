using System;
using ConnectionStringHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionStringHelperTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SQLDataSourceConnectionString()
        {
            var x=ConnectionString.GetSQLDataSourceConnectionString(".");
            Assert.AreEqual(x, "Data Source=.;Integrated Security=True");
        }
    }
}
