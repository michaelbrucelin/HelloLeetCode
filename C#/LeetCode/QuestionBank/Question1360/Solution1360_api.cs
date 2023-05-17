using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1360
{
    public class Solution1360_api : Interface1360
    {
        public int DaysBetweenDates(string date1, string date2)
        {
            DateTime dt1 = DateTime.ParseExact(date1, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(date2, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            return Math.Abs((dt1 - dt2).Days);
        }
    }
}
