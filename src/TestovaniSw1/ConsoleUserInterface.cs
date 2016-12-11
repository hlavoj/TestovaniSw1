using System;
using System.Collections.Generic;

namespace TestovaniSw1
{
    internal class ConsoleUserInterface
    {
        public static void WriteResult(double sum)
        {
            Console.WriteLine($"Your price is {sum}");
            Console.ReadLine();
        }

        public static void WriteAgeHint()
        {
            Console.WriteLine("enter your age:");
        }

        public static int ReadAge()
        {
            return int.Parse(Console.ReadLine());
        }

        public static string ReadProducts()
        {
            return Console.ReadLine();
        }

        public static void GetProgramInfo(double shipping, List<Product> products)
        {
            Console.WriteLine("Price Calculator 1.0");
            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("pri objednavce 2 a vice 10% sleva");
            Console.WriteLine("pro mladsi 26 a starsi 65 sleva 13% na socialni produkty");
            Console.WriteLine("pri nakupu nad 250 postovne zdarma  ");
            //Console.WriteLine("Maximalne 2 slevy najednou ");
            Console.WriteLine($"Doprava {shipping}");
            Console.WriteLine("----------------------------");

            Console.WriteLine("enter names of product what you want to buy (Separated by ','):");
        }
    }
}