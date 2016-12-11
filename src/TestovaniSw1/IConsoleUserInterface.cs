using System.Collections.Generic;

namespace TestovaniSw1
{
    public interface IConsoleUserInterface
    {
        void WriteResult(double sum);
        void WriteAgeHint();
        int ReadAge();
        string ReadProducts();
        void GetProgramInfo(double shipping, List<Product> products);
    }
}