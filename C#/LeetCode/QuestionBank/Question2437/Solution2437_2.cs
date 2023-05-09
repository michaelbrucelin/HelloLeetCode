using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2437
{
    public class Solution2437_2 : Interface2437
    {
        /// <summary>
        /// 模拟
        /// 用0-9替换?，本质上依然是暴力，而且复杂度比Solution2437高
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int CountTime(string time)
        {
            int hour = 0, minute = 0;

            if (time[0..2] == "??") hour = 24;
            else if (time[0] == '?') { for (int i = 0; i < 10; i++) if (int.Parse($"{i}{time[1]}") < 24) hour++; }
            else if (time[1] == '?') { for (int i = 0; i < 10; i++) if (int.Parse($"{time[0]}{i}") < 24) hour++; }
            else hour = 1;

            if (time[3..] == "??") minute = 60;
            else if (time[3] == '?') { for (int i = 0; i < 10; i++) if (int.Parse($"{i}{time[4]}") < 60) minute++; }
            else if (time[4] == '?') { for (int i = 0; i < 10; i++) if (int.Parse($"{time[3]}{i}") < 60) minute++; }
            else minute = 1;

            return hour * minute;
        }
    }
}
