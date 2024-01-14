using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2220
{
    public class Solution2220 : Interface2220
    {
        /// <summary>
        /// 计算异或结果中1的个数
        /// </summary>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public int MinBitFlips(int start, int goal)
        {
            int result = 0, xor = start ^ goal;
            while (xor > 0)
            {
                result++;
                xor &= xor - 1;
            }

            return result;
        }
    }
}
