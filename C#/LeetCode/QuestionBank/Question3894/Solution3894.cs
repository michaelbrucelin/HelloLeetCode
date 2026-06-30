using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3894
{
    public class Solution3894 : Interface3894
    {
        /// <summary>
        /// 分类讨论
        /// </summary>
        /// <param name="timer"></param>
        /// <returns></returns>
        public string TrafficSignal(int timer)
        {
            if (timer == 0) return "Green";
            if (timer == 30) return "Orange";
            if (timer > 30 && timer <= 90) return "Red";

            return "Invalid";
        }
    }
}
