using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace TestCompilacionConVariables
{
    class Program
    {
        public static DateTime fecha = new DateTime(2020, 2, 28, 23, 59, 59);
        static void Main(string[] args)
        {
            
        }


        public static int GetAtributeName(string key)
        {

            if (key.ToUpper().Equals("YEAR_BOMB"))
            {

            }


            var yearBomb = ConfigurationManager.AppSettings["YEAR_BOMB"];

            if (yearBomb != null)
            {
                return int.Parse(yearBomb);
            }
            else
            {
                return DateTime.MaxValue.Year;
            }
        }

        /// <summary>
        /// Get configurated year for time bomb. If null return max int year
        /// </summary>
        /// <returns></returns>
        public static int GetYearBomb()
        {
            var yearBomb = System.Configuration.ConfigurationManager.AppSettings["YEAR_BOMB"];

            if (yearBomb != null)
            {
                return int.Parse(yearBomb);
            }
            else
            {
                return DateTime.MaxValue.Year;
            }
        }

        public static int GetMonthBomb()
        {
            var monthBomb = ConfigurationManager.AppSettings["MONTH_BOMB"];

            if (monthBomb != null)
            {
                return int.Parse(monthBomb);
            }
            else
            {
                return DateTime.MaxValue.Month;
            }
        }

        public static int GetDayBomb()
        {
            var dayBomb = ConfigurationManager.AppSettings["DAY_BOMB"];

            if (dayBomb != null)
            {
                return int.Parse(dayBomb);
            }
            else
            {
                return DateTime.MaxValue.Day;
            }
        }

        public static int GetHourBomb()
        {
            var hourBomb = ConfigurationManager.AppSettings["HOUR_BOMB"];

            if (hourBomb != null)
            {
                return int.Parse(hourBomb);
            }
            else
            {
                return DateTime.MaxValue.Hour;
            }
        }

        public static int GetMinuteBomb()
        {
            var minuteBomb = ConfigurationManager.AppSettings["MINUTE_BOMB"];

            if (minuteBomb != null)
            {
                return int.Parse(minuteBomb);
            }
            else
            {
                return DateTime.MaxValue.Minute;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetSecondBomb()
        {
            var secondBomb = ConfigurationManager.AppSettings["HOUR_BOMB"];

            if (secondBomb != null)
            {
                return int.Parse(secondBomb);
            }
            else
            {
                return DateTime.MaxValue.Second;
            }
        }
    }
}
