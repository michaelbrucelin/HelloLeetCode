using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2427
{
    public class Solution2427 : Interface2427
    {
        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int CommonFactors(int a, int b)
        {
            int result = 0, high = Math.Min(a, b);
            for (int i = 1; i <= high; i++)
                if (a % i == 0 && b % i == 0) result++;

            return result;
        }
    }
}
