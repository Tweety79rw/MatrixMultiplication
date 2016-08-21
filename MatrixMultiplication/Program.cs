using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int> { 1, 2, 3 });
            temp.Add(new List<int> { 4, 5, 6 });
            temp.Add(new List<int> { 7, 8, 9 });
            Matrix m = new Matrix(temp);
            Console.WriteLine(m.ToString());
            Matrix trasposed = new Matrix(m.getTransposeMatrix());
            
            Console.WriteLine(trasposed.ToString());

            Console.ReadKey();
        }
    }
}
