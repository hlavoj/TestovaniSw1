using System;
using System.Collections.Generic;
using System.Linq;

namespace TestovaniSw1
{
    internal class Program
    {
        internal static double Shipping => 50;
        internal static List<Product> Products => new List<Product>(3)
            {
                new Product {Name = "Scisors", Price = 200},
                new Product {Name = "NewsPaper" , Price = 10},
                new Product {Name = "Magazine" , Price = 100},
                new Product {Name = "Apple" , Price = 1000 , IsSocialProduct = true}
            };

        static void Main(string[] args)
        {

            Console.WriteLine("Price Calculator 1.0");
            Console.WriteLine("Products:");
            foreach (var product in Products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("pri objednavce 2 a vice 10% sleva");
            Console.WriteLine("pro mladsi 26 a starsi 65 sleva 13% na socialni produkty");
            Console.WriteLine("pri nakupu nad 250 postovne zdarma  ");
            //Console.WriteLine("Maximalne 2 slevy najednou ");
            Console.WriteLine($"Doprava {Shipping}");
            Console.WriteLine("----------------------------");

            Console.WriteLine("enter names of product what you want to buy (Separated by ','):");
            var productsString = Console.ReadLine();
            var productsInput = productsString.Split(',');

            for (int i = 0; i < productsInput.Length; i++)
            {
                productsInput[i] = productsInput[i].ToLower().Trim();
            }

            var selectedProducts = (from product in Products
                                    where productsInput.Contains(product.Name.ToLower())
                                    select product).ToList();

            Console.WriteLine("enter your age:");
            var age = int.Parse(Console.ReadLine());

            var sum = GetPrice(age, selectedProducts, Shipping);

            Console.WriteLine($"Your price is {sum}");
            Console.ReadLine();
        }

        internal static double GetPrice(int age, List<Product> selectedProducts, double shipping)
        {
            double sum = 0;
            if (age < 26 || age > 65)
            {
                foreach (var selectedProduct in selectedProducts)
                {
                    if (selectedProduct.IsSocialProduct)
                    {
                        sum += selectedProduct.Price*0.87;
                    }
                    else
                    {
                        sum += selectedProduct.Price;
                    }
                }
            }
            else
            {
                sum = selectedProducts.Sum(product => product.Price);
            }

            if (selectedProducts.Count > 1)
            {
                sum = sum*0.9;
            }

            if (sum <= 250)
            {
                sum += shipping;
            }
            return sum;
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsSocialProduct { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }

}
