using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleWCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA2_AzureTests;

// Testing Console WCF Service
namespace ConsoleWCFService.Tests
{
    [TestClass()]
    public class TeaServiceTests
    {
        TeaService service = new TeaService();
        MockDB testdb = new MockDB();

        // test names of tea
        [TestMethod()]
        public void GetTeaNamesTest()
        {
            var result = service.GetTeaNames();

            Assert.AreEqual("Biluochun, Longjing, Jinjumei, Bai Mudan, Menghai 8582, Menghai 7592, Menghai 7742, Haiwan LaoTongZhi, Maofen", result);

        }

        // test data output about selected tea
        [TestMethod()]
        public void GetTeaInfoTest()
        {
            var result = service.GetTeaInfo("Longjing");

            string expectedResult = "ID: " + testdb.getTea(2).Id + ", Type: " + testdb.getTea(2).Type + ", Name: " + testdb.getTea(2).Name + ", Quantity: " + testdb.getTea(2).Qty + ", Price: " + testdb.getTea(2).Price + ", Year: " + testdb.getTea(2).Year;

            Assert.AreEqual(expectedResult, result);
        }
    }
}