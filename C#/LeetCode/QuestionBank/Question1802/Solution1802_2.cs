using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1802
{
    public class Solution1802_2 : Interface1802
    {
        /// <summary>
        /// 数学题
        /// 具体见Solution1802_2.md
        /// </summary>
        /// <param name="n"></param>
        /// <param name="index"></param>
        /// <param name="maxSum"></param>
        /// <returns></returns>
        public int MaxValue(int n, int index, int maxSum)
        {
            if (maxSum - n <= 1) return maxSum - n + 1;

            int k = maxSum - n;
            int left = (int)Math.Floor(Math.Sqrt(k)) + 1, right = (k * 2 / n + n + 1) >> 1;
            int result = 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                long add;
                if (mid <= index + 2 && mid <= n - index + 1)
                    add = 1L * (mid - 1) * (mid - 1);
                else if (mid > index + 2 && mid <= n - index + 1)
                    add = (1L * (mid * 2 - index - 2) * (index + 1) + 1L * (mid - 2) * (mid - 1)) >> 1;
                else if (mid <= index + 2 && mid > n - index + 1)
                    add = (1L * (n - index) * (mid * 2 + index - n - 1) + 1L * (mid - 2) * (mid - 1)) >> 1;
                else  // if (mid > index + 2 && mid > n - index + 1)
                    add = ((1L * (mid * 2 - index - 2) * (index + 1) + 1L * (n - index) * (mid * 2 + index - n - 1)) >> 1) - (mid - 1);

                if (add <= k)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
