using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2960
{
    public class Solution2960 : Interface2960
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="batteryPercentages"></param>
        /// <returns></returns>
        public int CountTestedDevices(int[] batteryPercentages)
        {
            int result = 0;
            for (int i = 0; i < batteryPercentages.Length; i++)
            {
                if (batteryPercentages[i] > result) result++;
            }

            return result;
        }
    }
}
