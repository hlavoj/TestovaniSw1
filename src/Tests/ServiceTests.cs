using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestovaniSw1;

namespace Tests
{
    [TestClass]
    public class ServiceTests
    {
        internal static List<Product> Products => new List<Product>(3)
            {
                new Product {Name = "Scisors", Price = 200},
                new Product {Name = "NewsPaper" , Price = 10},
                new Product {Name = "Magazine" , Price = 100},
                new Product {Name = "Apple" , Price = 1000 , IsSocialProduct = true}
            };


        [TestMethod]
        public void InputTest()
        {
            var newsPaper = new Product { Name = "NewsPaper", Price = 100 };
            var apple = new Product { Name = "Apple", Price = 1000, IsSocialProduct = true };

            var res = CalculatorService.GetSelectedProducts("Apple , NeWsPaper  ", Products);
            Assert.IsTrue(res.Contains(newsPaper));
            Assert.IsTrue(res.Contains(apple));
        }
    }
}
