using System;
using System.Collections.Generic;
using System.Linq;

namespace TestovaniSw1
{
    internal class Program
    {
        private static double Shipping = 50;
        private static List<Product> Products = new List<Product>(3)
            {
                new Product {Name = "Scisors", Price = 200},
                new Product {Name = "NewsPaper" , Price = 10},
                new Product {Name = "Magazine" , Price = 100},
                new Product {Name = "Apple" , Price = 1000 , IsSocialProduct = true}
            };

        static void Main(string[] args)
        {
            ConsoleUserInterface consoleUserInterface = new ConsoleUserInterface();
            CalculatorService.CalculatePrice(consoleUserInterface, Shipping, Products);
        }
    }
}
