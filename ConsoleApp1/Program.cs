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
            Print(mat);


            Console.Write("Enter your start day: ");
            int inputDay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your start month: ");
            int inputMonth = Convert.ToInt32(Console.ReadLine());
            //date = Convert.ToDateTime(Console.ReadLine());
            DateTime date = new DateTime(2019, inputMonth, inputDay);
            Console.WriteLine(date.ToString("dd/MM/yyyy"));

            Console.Write("Enter how much days: ");
            int days = Convert.ToInt32(Console.ReadLine());
            //int days = 10;

            addReservation(mat, date, days);

            Console.ReadKey();
        }

        private static bool addReservation(bool[][] mat, DateTime date, int days)
        {
            Console.WriteLine("{0} / {1}", date.Month, date.Day);
            for (int i = 0; i < days; i++)
            {
                DateTime tempDate = date;
                //Console.Write(" -> {0} ", date.ToString("dd/MM/yyyy"));
                //Console.WriteLine("Day-> {0} / {1} <-Month", date.Day, date.Month);
                if (mat[tempDate.Month - 1][tempDate.Day - 1] == true)
                {
                    return false;
                };
                tempDate = tempDate.AddDays(1);

                if (mat[date.Month - 1][date.Day - 1] == false)
                {
                    mat[date.Month - 1][date.Day - 1] = true;
                };
                date = date.AddDays(1);

            }
            Print(mat);
            return true;

        }

        private static void Print(bool[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j]) Console.Write(" T ");
                    else Console.Write(" F ");
                }
                Console.WriteLine();
            }
        }

    }
}
