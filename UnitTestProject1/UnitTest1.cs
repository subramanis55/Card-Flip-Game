using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardFlip.Database;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DBManager dBManager = new DBManager("192.168.3.63", "Temp", "root", "lucid123");
            var x =dBManager.Result("suriya", TimeSpan.FromMinutes(1));
            Assert.IsTrue(x == 0);
        }
    }
}
