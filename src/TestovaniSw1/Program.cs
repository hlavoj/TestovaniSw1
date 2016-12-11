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
            var selectedProducts = GetSelectedProducts(productsString);

            Console.WriteLine("enter your age:");
            var age = int.Parse(Console.ReadLine());

            var sum = PriceCalculator.GetPrice(age, selectedProducts, Shipping);

            Console.WriteLine($"Your price is {sum}");
            Console.ReadLine();
        }

        internal static List<Product> GetSelectedProducts(string productsString)
        {
            var productsInput = productsString.Split(',');

            for (int i = 0; i < productsInput.Length; i++)
            {
                productsInput[i] = productsInput[i].ToLower().Trim();
            }

            var selectedProducts = (from product in Products
                where productsInput.Contains(product.Name.ToLower())
                select product).ToList();
            return selectedProducts;
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

        protected bool Equals(Product other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }

}
