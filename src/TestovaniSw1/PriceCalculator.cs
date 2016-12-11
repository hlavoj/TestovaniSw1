using System.Collections.Generic;
using System.Linq;

namespace TestovaniSw1
{
    internal class PriceCalculator
    {
        internal static double GetPrice(int age, List<Product> selectedProducts, double shipping)
        {
            double sum = 0;
            if (age < 26 || age > 65)
            {
                sum = ApplyOldDiscount(selectedProducts, sum);
            }
            else
            {
                sum = selectedProducts.Sum(product => product.Price);
            }

            sum = ApplyCountDiscount(selectedProducts, sum);

            sum = ApplyShippingDiscount(shipping, sum);
            return sum;
        }

        private static double ApplyOldDiscount(List<Product> selectedProducts, double sum)
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
            return sum;
        }

        private static double ApplyCountDiscount(List<Product> selectedProducts, double sum)
        {
            if (selectedProducts.Count > 1)
            {
                sum = sum*0.9;
            }
            return sum;
        }

        private static double ApplyShippingDiscount(double shipping, double sum)
        {
            if (sum <= 250)
            {
                sum += shipping;
            }
            return sum;
        }
    }
}