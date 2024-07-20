using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3200
{
    public class Solution3200_2 : Interface3200
    {
        /// <summary>
        /// 数学
        /// 1 3 5 7 9 单数层N层的话，需要N^2个球，2 4 6 8 10 双数层N层的话，需要N(N+1)个球
        /// </summary>
        /// <param name="red"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        public int MaxHeightOfTriangle(int red, int blue)
        {
            int odd, even, result1, result2;

            // 红球单层，蓝球双层
            odd = (int)Math.Sqrt(red); even = (int)(Math.Sqrt(blue + 0.25) - 0.5);
            result1 = odd > even ? (even << 1) + 1 : (odd << 1);

            // 红球双层，蓝球单层
            odd = (int)Math.Sqrt(blue); even = (int)(Math.Sqrt(red + 0.25) - 0.5);
            result2 = odd > even ? (even << 1) + 1 : (odd << 1);

            return Math.Max(result1, result2);
        }
    }
}
