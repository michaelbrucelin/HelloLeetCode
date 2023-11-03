using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1185
{
    public class Solution1185_api : Interface1185
    {
        public string DayOfTheWeek(int day, int month, int year)
        {
            return (new DateTime(year, month, day)).DayOfWeek.ToString();
        }
    }
}
