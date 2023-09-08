using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2651
{
    public class Solution2651 : Interface2651
    {
        /// <summary>
        /// 取模
        /// </summary>
        /// <param name="arrivalTime"></param>
        /// <param name="delayedTime"></param>
        /// <returns></returns>
        public int FindDelayedArrivalTime(int arrivalTime, int delayedTime)
        {
            return (arrivalTime + delayedTime) % 24;
        }
    }
}
