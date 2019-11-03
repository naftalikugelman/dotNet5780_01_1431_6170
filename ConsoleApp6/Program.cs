using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Lottery numbers randomly
            Random rnd = new Random(DateTime.Now.Millisecond);

            //three arrays
            int[] A = new int[20];
            int[] B = new int[20];
            int[] C = new int[20];
            Console.Write("A:");
            for (int i = 0; i < 20; i++)
            {
                A[i] = rnd.Next(18, 122);
                Console.Write("  {0,-3}", A[i]);
            }
            Console.WriteLine();
            Console.Write("B:");
            for (int i = 0; i < 20; i++)
            {
                B[i] = rnd.Next() % 102 + 18;
                Console.Write("  {0,-3}", B[i]);
            }
            Console.WriteLine();
            Console.Write("C:");

            //absolute diference value between array A and array B
            for (int i = 0; i < 20; i++)
            {
                C[i] = Math.Abs(B[i]-A[i]);
                Console.Write("  {0,-3}", C[i]);
            }
            Console.WriteLine();
        }
    }
}
