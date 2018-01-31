using WebAPIService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CA2_Azure.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CA2_Azure.Models;
using CA2_AzureTests;
using System.ComponentModel.DataAnnotations;
using CA2_Azure.ServiceLayer;


namespace CA2_Azure.Controllers.Tests
{
    [TestClass()]
    public class TeasControllerTests
    {
        MockDB testdb = new MockDB();

        [TestMethod()]
        //test data get from DB versus mock DB with same data
        public void DetailsTest()
        {
            TeasController controller = new TeasController();
            var result = controller.Details(1) as ViewResult;
            var data = (Tea)result.ViewData.Model;

            Assert.AreEqual(testdb.getTea(1).Name, data.Name);
        }

        [TestMethod()]
        // Validation fails if quantity or price are less than zero or year has more(or less) than 4 numbers)
        public void validatationTest()
        {
            List<TeaMetaData> testlist = new List<TeaMetaData>
            {
               new TeaMetaData {Id=3, Type="Black Tea", Name="Jinjumei", Qty=-100, Price=8.5, Year="2016"},
               new TeaMetaData {Id=3, Type="Black Tea", Name="Jinjumei", Qty=3000, Price=-10, Year="2016"},
               new TeaMetaData {Id=3, Type="Black Tea", Name="Jinjumei", Qty=3000, Price=8.5, Year="201617"}
            };

            foreach (TeaMetaData tea in testlist)
            {
                var model = tea;
                var context = new ValidationContext(model, null, null);
                var result = new List<ValidationResult>();
                var valid = Validator.TryValidateObject(model, context, result, true);

                Assert.IsFalse(valid);
            }
        }
    }
}