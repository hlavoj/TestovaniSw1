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
            CalculatePrice(consoleUserInterface, Shipping, Products);
        }

        internal static void CalculatePrice(IConsoleUserInterface consoleUserInterface, double shipping, List<Product> products)
        {     
            consoleUserInterface.GetProgramInfo(shipping, products);

            var productsString = consoleUserInterface.ReadProducts();
            var selectedProducts = GetSelectedProducts(productsString, products);

            consoleUserInterface.WriteAgeHint();
            var age = consoleUserInterface.ReadAge();
            var sum = PriceCalculator.GetPrice(age, selectedProducts, shipping);

            consoleUserInterface.WriteResult(sum);
        }

        internal static List<Product> GetSelectedProducts(string productsString, List<Product> products)
        {
            var productsInput = productsString.Split(',');

            for (int i = 0; i < productsInput.Length; i++)
            {
                productsInput[i] = productsInput[i].ToLower().Trim();
            }

            var selectedProducts = (from product in products
                                    where productsInput.Contains(product.Name.ToLower())
                                    select product).ToList();
            return selectedProducts;
        }
    }
}
