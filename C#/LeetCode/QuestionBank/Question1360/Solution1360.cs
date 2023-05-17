using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1360
{
    public class Solution1360 : Interface1360
    {
        private static readonly int[] days = new int[] { -1, 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        /// <summary>
        /// 逐步计算
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public int DaysBetweenDates(string date1, string date2)
        {
            if (string.CompareOrdinal(date1, date2) > 0) (date1, date2) = (date2, date1);
            int YY1 = int.Parse(date1[0..4]), MM1 = int.Parse(date1[5..7]), DD1 = int.Parse(date1[8..]);
            int YY2 = int.Parse(date2[0..4]), MM2 = int.Parse(date2[5..7]), DD2 = int.Parse(date2[8..]);

            int result = 0;
            if (YY1 == YY2)
            {
                if (MM1 == MM2) result = Math.Abs(DD2 - DD1);
                else
                {
                    result += GetMonthDays(YY1, MM1, DD1);
                    for (int mm = MM1 + 1; mm < MM2; mm++) result += GetMonthDays(YY1, mm);
                    result += DD2;
                }
            }
            else
            {
                result += GetMonthDays(YY1, MM1, DD1);
                for (int mm = MM1 + 1; mm < 13; mm++) result += GetMonthDays(YY1, mm);
                for (int yy = YY1 + 1; yy < YY2; yy++) result += IsLeapYear(yy) ? 366 : 365;
                for (int mm = 1; mm < MM2; mm++) result += GetMonthDays(YY2, mm);
                result += DD2;
            }

            return result;
        }

        private int GetMonthDays(int year, int month, int day)
        {
            if (month != 2) return days[month] - day;
            if (IsLeapYear(year)) return 29 - day; else return 28 - day;
        }

        private int GetMonthDays(int year, int month)
        {
            if (month != 2) return days[month];
            if (IsLeapYear(year)) return 29; else return 28;
        }

        private bool IsLeapYear(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year");
            }

            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
    }
}
