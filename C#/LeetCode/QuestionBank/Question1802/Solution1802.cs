using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1802
{
    public class Solution1802 : Interface1802
    {
        /// <summary>
        /// 数学题
        /// 具体见Solution1802.md
        /// </summary>
        /// <param name="n"></param>
        /// <param name="index"></param>
        /// <param name="maxSum"></param>
        /// <returns></returns>
        public int MaxValue(int n, int index, int maxSum)
        {
            if (maxSum - n <= 1) return maxSum - n + 1;

            if (index > ((n - 1) >> 1)) index = n - 1 - index;
            int result = (int)((maxSum + ((1L * (n - index) * (n - index) + 1L * (index + 1) * (index + 1) - n - 1) >> 1)) / n);
            int left = result - index, right = result - n + index + 1;
            while (right <= 0)
            {
                n -= (1 - right); maxSum -= (1 - right);
                if (left <= 0)
                {
                    n -= (1 - left); maxSum -= (1 - left); index -= (1 - left);
                }
                return MaxValue(n, index, maxSum);
            }

            return result;
        }
    }
}
