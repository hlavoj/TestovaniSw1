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
        internal static List<Product> Products => new List<Product>(3)
            {
                new Product {Name = "Scisors", Price = 200},
                new Product {Name = "NewsPaper" , Price = 10},
                new Product {Name = "Magazine" , Price = 100},
                new Product {Name = "Apple" , Price = 1000 , IsSocialProduct = true}
            };

        [TestMethod]
        public void SimplePrice()
        {

            var res = PriceCalculator.GetPrice(40, Products.Where(product => product.Name == "Scisors").ToList(), 50);
            Assert.AreEqual(250, res);
        }


        [TestMethod]
        public void TwoProductPrice()
        {
            var res = PriceCalculator.GetPrice(40, Products.Where(p => p.Name == "Scisors" || p.Name == "NewsPaper").ToList(), 50);
            Assert.AreEqual(239, res);
        }

        [TestMethod]
        public void SimpleOldPeoplePrice()
        {

            var res = PriceCalculator.GetPrice(99, Products.Where(product => product.Name == "Apple").ToList(), 50);
            Assert.AreEqual(870, res);
        }


        [TestMethod]
        public void TwoProductOldPeoplPrice()
        {
            var res = PriceCalculator.GetPrice(99, Products.Where(p => p.Name == "Apple" || p.Name == "NewsPaper").ToList(), 50);
            Assert.AreEqual(792, res);
        }



    }
}
