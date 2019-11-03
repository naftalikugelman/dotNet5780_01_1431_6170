using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean[][] mat = new Boolean[12][];
            for (int i = 0; i < mat.Length; i++)
            {
                mat[i] = new Boolean[31];
                for (int j = 0; j < mat[i].Length; j++)
                {
                    mat[i][j] = false;
                }
            }
            //print
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    Console.Write(" {0}",mat[i][j]);
                }
                Console.WriteLine();
            }

            DateTime date = new DateTime();
            Console.Write("Enter your start date: ");
            date = Convert.ToDateTime(Console.ReadLine());
            //Console.WriteLine(date);

            Console.Write("Enter how much days: ");
            int days = Convert.ToInt32(Console.ReadLine());
            
            //check is aveilable
            DateTime tempDate = new DateTime();
            tempDate = date;
            int countDays = 1;
            tempDate.AddDays(1);
            for(int i = 0; i < days; i++)
            {
                if (mat[tempDate.Month][tempDate.Day] = false)
                {
                    tempDate.AddDays(1);
                    countDays++;
                };
            }



        }
    }
}
