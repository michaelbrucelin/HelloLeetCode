using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1360
{
    public class Solution1360_2 : Interface1360
    {
        private static readonly int[,] days = new int[2, 13]{
            { 365, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 },
            { 366, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }
        };

        /// <summary>
        /// 逐步计算
        /// 与Solution1360本质上一样，但是代码上进行了优化
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
                    result += IsLeapYear(YY1) ? days[1, MM1] - DD1 : days[0, MM1] - DD1;
                    for (int mm = MM1 + 1; mm < MM2; mm++) result += IsLeapYear(YY1) ? days[1, mm] : days[0, mm];
                    result += DD2;
                }
            }
            else
            {
                result += IsLeapYear(YY1) ? days[1, MM1] - DD1 : days[0, MM1] - DD1;
                for (int mm = MM1 + 1; mm < 13; mm++) result += IsLeapYear(YY1) ? days[1, mm] : days[0, mm];
                for (int yy = YY1 + 1; yy < YY2; yy++) result += IsLeapYear(yy) ? 366 : 365;
                for (int mm = 1; mm < MM2; mm++) result += IsLeapYear(YY2) ? days[1, mm] : days[0, mm];
                result += DD2;
            }

            return result;
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
