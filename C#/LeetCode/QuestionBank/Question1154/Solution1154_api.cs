using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1154
{
    public class Solution1154_api : Interface1154
    {
        public int DayOfYear(string date)
        {
            DateTime dt = Convert.ToDateTime(date);
            DateTime dt0 = Convert.ToDateTime($"{date[0..4]}-01-01");

            return (int)(dt - dt0).TotalDays + 1;
        }
    }
}
