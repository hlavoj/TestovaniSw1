using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestovaniSw1;

namespace Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void SimplePrice()
        {

            var res = PriceCalculator.GetPrice(40, Program.Products.Where(product => product.Name == "Scisors").ToList(), 50);
            Assert.AreEqual(250, res);
        }


        [TestMethod]
        public void TwoProductPrice()
        {
            var res = PriceCalculator.GetPrice(40, Program.Products.Where(p => p.Name == "Scisors" || p.Name == "NewsPaper").ToList(), 50);
            Assert.AreEqual(239, res);
        }

        [TestMethod]
        public void SimpleOldPeoplePrice()
        {

            var res = PriceCalculator.GetPrice(99, Program.Products.Where(product => product.Name == "Apple").ToList(), 50);
            Assert.AreEqual(870, res);
        }


        [TestMethod]
        public void TwoProductOldPeoplPrice()
        {
            var res = PriceCalculator.GetPrice(99, Program.Products.Where(p => p.Name == "Apple" || p.Name == "NewsPaper").ToList(), 50);
            Assert.AreEqual(792, res);
        }


        [TestMethod]
        public void InputTest()
        {
            var newsPaper = new Product { Name = "NewsPaper", Price = 100 };
            var apple = new Product { Name = "Apple", Price = 1000, IsSocialProduct = true };

            var res = Program.GetSelectedProducts("Apple , NeWsPaper  ");
            Assert.IsTrue(res.Contains(newsPaper));
            Assert.IsTrue(res.Contains(apple));
        }

    }
}
