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
    
    class Date //Class to handle the dates
    {
        int day;
        int month;

        public int Day // getter and setter
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        //Jump to next day respecting the monthes
        public void nextDay()
        {
            if (day == 31)//need to go to nrxt month
            {
                day = 1;
                if (month == 12) month = 1;//restart the year
                else ++month;
            }
            else ++day;// just jump
        }
        //prints the current date
        public void print()
        {
            Console.WriteLine("{0}/{1}/2020", day, month);
        }

        //Return as a string
        public string toString()
        {
            return day.ToString() + "/" + month.ToString();
        }

        //Constrooctor
        public Date(int d, int m)
        {
            day = d;
            month = m;
        }
        //default constroctor
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
            Boolean[][] mat = new Boolean[12][];//our calendar
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
                
         1 - New reservation - 
         2 - Print the anual reserved dates -
         3 - Days per year and percentage of the year - 
         4 - Exit ): - ");

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
                if (mat[tempDate.Month - 1][tempDate.Day - 1])//Cheking if there is no other reservation at the same dates
                {
                    return false;
                }
                tempDate.nextDay();//jumps to next date
            }
            //After we know that there is no reservation we can add a new reservation
            for (int i = 0; i < days; i++)
            {
                mat[dateTemp.Month - 1][dateTemp.Day - 1] = true; //to get the current date we need to add - 1
                dateTemp.nextDay();
            }

            return true;//Confirm that the new reservation has been added
        }

        //For debuging propouses only...
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


        //prints all the dates that have reservations at this year
        private static void printDates(bool[][] mat)
        {
            string finalText = "Located Dates:\n";//Will print thus string at the end
            bool flag = false;// flag to know if we are at a middle of an reservation or if we just started
            for (int i = 0; i < 12; i++)//run over the monthes
            {
                for (int j = 0; j < 31; j++)//run over the days
                {
                    if (!flag && mat[i][j])//If this day is reservated AND the last one hasn`t
                    {
                        flag = true;//set flag to true so we van now that next TRUE day is in a middle of a reservation
                        finalText += "from " + (j + 1) + "/" + (i + 1) + " to ";//Adds the date to final print string
                    }
                    if (flag && !mat[i][j])//If we have an FALSE day AND aur last day was a TRUE, so this reservation ends here...
                    {
                        finalText += (j + 1) + "/" + (i + 1) + "\n";//Adds the final date to the final string
                        flag = false;//sets the flagh to flase
                    }
                }
            }
            Console.WriteLine(finalText);
        }

        //runs over all year and counts how many days has reservations over the year
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

        //calculates the porcentage
        private static float percentageOfOccupancy(bool[][] mat)
        {
            float Days = 372;
            float per;
            per = (sumOfDate(mat) / Days) * 100;
            
            return per;
        }
    }
}
