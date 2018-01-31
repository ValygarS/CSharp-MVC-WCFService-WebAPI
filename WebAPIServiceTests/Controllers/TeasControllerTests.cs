using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA2_AzureTests;
using WebAPIService.Models;
using System.Web.Http.Results;

namespace WebAPIService.Controllers.Tests
{
    [TestClass()]
    public class TeasControllerTests
    {

        MockDB testdb = new MockDB();

        // testing that items count returned from real DB same as in MockDB
        [TestMethod()]
        public void GetTeasTest()
        {
            var controller = new TeasController();
            var result = controller.GetTeas();

            Assert.AreEqual(testdb.getAll().Count(), result.Count());
        }

        // should return correct tea
        [TestMethod()]
        public void GetTeaTest()
        {
            var controller = new TeasController();

            var result = controller.GetTea(1) as OkNegotiatedContentResult<Tea>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testdb.getTea(1).Name, result.Content.Name);
        }

        [TestMethod]
        public void GetTea_ShouldNotFindTea()
        {
            var controller = new TeasController();

            var result = controller.GetTea(1000);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

    }
}