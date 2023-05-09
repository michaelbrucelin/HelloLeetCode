using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2437
{
    public class Solution2437 : Interface2437
    {
        /// <summary>
        /// 暴力枚举
        /// 既然一共只有1440种可能，那就可以暴力解
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int CountTime(string time)
        {
            int result = 0;
            string _time; bool flag;
            for (int hh = 0; hh < 24; hh++) for (int mm = 0; mm < 60; mm++)
                {
                    _time = $"{hh:D2}:{mm:D2}"; flag = true;
                    for (int i = 0; i < 5; i++)
                    {
                        if (time[i] != '?' && time[i] != _time[i]) { flag = false; break; }
                    }
                    if (flag) result++;
                }

            return result;
        }
    }
}
