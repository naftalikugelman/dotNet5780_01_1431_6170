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

                        Console.Write("Enter the start day reservation (dd/mm/yyyy): ");
                        DateTime date = Convert.ToDateTime(Console.ReadLine());
                        date = new DateTime(date.Year, date.Month, date.Day);
                        Console.WriteLine(date.ToString("dd/MM/yyyy"));
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
                        Print(mat);

                        break;
                    case 2:
                        Console.WriteLine("Annual Occupancy List");
                        break;
                    case 3:
                        Console.WriteLine("Total occupied days");
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

        private static bool addReservation(bool[][] mat, DateTime date, int days)
        {

            for (int i = 0; i < days; i++)
            {
                DateTime tempDate = new DateTime();
                
                tempDate = date;//WRONG******WRONG****WRONG****WRONG***WRONG****WRONG*****WRONG****WRONG*****WRONG****WRONG**WRONG


                //tempDate(date.Year, date.Month, date.Day);
                //Console.Write(" -> {0} ", date.ToString("dd/MM/yyyy"));
                //Console.WriteLine("Day-> {0} / {1} <-Month", date.Day, date.Month);

                if (mat[tempDate.Month - 1][tempDate.Day -1] == true)// delete -1 becose wee needed to check after
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
            //Print(mat);
            return true;

        }

        private static void Print(bool[][] mat)
        {
            string rented = null;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j])
                    {
                        Console.Write(" T ");
                        //Console.WriteLine(getCompleteReservation(mat, i, j));
                        if (rented == null)
                        {
                            rented = getCompleteReservation(mat, i, j);
                        }

                    }
                    else
                    {
                        Console.Write(" F ");

                    }

                }
                if (!(rented == null))
                {
                    Console.Write(rented);
                    rented = null;
                }
                Console.WriteLine();
            }
        }

        private static string getCompleteReservation(bool[][] mat, int i, int j)
        {
            int inicialMonth = i;
            int inicialDay = j;
            DateTime date;

            //date = new DateTime(2020, 4, 4);
            date = new DateTime(2020, i, j);
            while (mat[date.Month][date.Day])
            {
                date = date.AddDays(1);
            }
            // Console.WriteLine(j, i, date.Day, date.Month);
            //Console.WriteLine(date.Month);
            //Console.WriteLine(i);
            return "-> Rented from " + (j + 1) + "/" + (i + 1) + " to " + (date.Day + 1) + "/" + (date.Month + 1);
        }
    }
}
