using System.Collections.Generic;
using System.Linq;

namespace TestovaniSw1
{
    internal class CalculatorService
    {
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