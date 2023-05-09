using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2437
{
    public class Solution2437_3 : Interface2437
    {
        /// <summary>
        /// 排列组合
        /// 1. 分钟相互独立，第1位取0-5，第2位取0-9
        /// 2. 小时相互制约，第1位取0-1时，第2位取0-9
        ///                  第1位取 2 时，第2位取0-3
        ///                  第2位取0-3时，第1位取0-2
        ///                  第2位取4-9时，第1位取0-1
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int CountTime(string time)
        {
            int hour, minute;

            if (time[0..2] == "??") hour = 24;
            else if (time[0] == '?') { if (time[1] < '4') hour = 3; else hour = 2; }
            else if (time[1] == '?') { if (time[0] < '2') hour = 10; else hour = 4; }
            else hour = 1;

            if (time[3..] == "??") minute = 60;
            else if (time[3] == '?') minute = 6;
            else if (time[4] == '?') minute = 10;
            else minute = 1;

            return hour * minute;
        }
    }
}
