using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1154
{
    public class Solution1154 : Interface1154
    {
        public int DayOfYear(string date)
        {
            int[] days = new int[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
            int year = int.Parse(date[0..4]), month = int.Parse(date[5..7]), day = int.Parse(date[8..10]);
            int extra = (((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) && month > 2) ? 1 : 0;

            return days[month - 1] + day + extra;
        }
    }
}
