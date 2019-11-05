//Daniel Vofchuk & Naftali Kugelmann
//00091431 & 305606170
//Part 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Date
    {
        int day;
        int month;

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public void nextDay()
        {
            if (day == 31)
            {
                day = 1;
                if (month == 12) month = 1;
                else ++month;
            }
            else ++day;
        }

        public void print()
        {
            Console.WriteLine("{0}/{1}/2020", day, month);
        }

        public string toString()
        {
            return day.ToString() + "/" + month.ToString();
        }

        public Date(int d, int m)
        {
            day = d;
            month = m;
        }

        public Date()
        {
            day = 0;
            month = 0;
        }

    }
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

            int choise = 0;
            while (choise != 4)
            {
                Console.WriteLine(@"Please choose a menu option: 
                
         1 - NEW RESERVATION - 
         2 - ANNUAL LIST -
         3 - DAILY LIST - 
         4 - EXIT - ");

                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:

                        Console.Write("Enter the start day reservation - day: ");
                        Date date = new Date();
                        date.Day = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the start month reservation - month: ");
                        date.Month = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter how much days: ");
                        int days = Convert.ToInt32(Console.ReadLine());

                        if (addReservation(mat, date, days))
                        {
                            Console.WriteLine("The request was approved");
                        }
                        else
                        {
                            Console.WriteLine("The resquest  was rejected");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Annual Occupancy List");
                        //PrintCalander(mat);
                        //Console.WriteLine("\n");
                        printDates(mat);
                        break;
                    case 3:
                        Console.WriteLine("Total occupied days: ");
                        Console.WriteLine("sum of days: {0}", sumOfDate(mat));
                        Console.WriteLine("percent of year: {0:f}",percentageOfOccupancy(mat));
                        break;
                    case 4:
                        Console.WriteLine("Thanks for using our system!");

                        break;
                    default:
                        break;
                }
            }

            Console.ReadKey();

        }

        private static bool addReservation(bool[][] mat, Date date, int days)
        {
            Date tempDate = new Date(date.Day + 1, date.Month);
            Date dateTemp = new Date(date.Day, date.Month);
            for (int i = 0; i < days - 1; ++i)
            {
                if (mat[tempDate.Month - 1][tempDate.Day - 1])
                {
                    return false;
                }
                tempDate.nextDay();
            }

            for (int i = 0; i < days; i++)
            {
                mat[dateTemp.Month - 1][dateTemp.Day - 1] = true;
                dateTemp.nextDay();
            }

            return true;
        }

        private static void PrintCalander(Boolean[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (mat[i][j]) Console.Write(" T ");
                    else Console.Write(" F ");
                }
                Console.WriteLine();
            }
        }



        private static void printDates(bool[][] mat)
        {
            string finalText = "Located Dates:\n";
            bool flag = false;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (!flag && mat[i][j])
                    {
                        flag = true;
                        finalText += "from " + (j + 1) + "/" + (i + 1) + " to ";
                    }
                    if (flag && !mat[i][j])
                    {
                        finalText += (j + 2) + "/" + (i + 2) + "\n";
                        flag = false;
                    }
                }
            }
            Console.WriteLine(finalText);
        }

        private static int sumOfDate(bool[][] mat)
        {
            int sum = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (mat[i][j]) sum++;
                }
            }
            return sum;
        }

        private static float percentageOfOccupancy(bool[][] mat)
        {
            float Days = 372;
            float per;
            per = (sumOfDate(mat) / Days) * 100;
            
            return per;
        }
    }
}
