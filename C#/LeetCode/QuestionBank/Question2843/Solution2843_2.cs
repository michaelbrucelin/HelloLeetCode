using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2843
{
    public class Solution2843_2 : Interface2843
    {
        /// <summary>
        /// 与Solution2843逻辑一样，稍加优化
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int CountSymmetricIntegers(int low, int high)
        {
            int result = 0;
            for (int i = low; i <= high; i++)
            {
                if (i <= 10 || (i >= 100 && i <= 1000)) continue;
                if (IsSymmetricInteger(i)) result++;
            }

            return result;
        }

        private bool IsSymmetricInteger(int x)
        {
            int len = (int)Math.Ceiling(Math.Log10(x + 1));
            // if ((len & 1) != 0) return false;

            len >>= 1;
            int sum1 = 0, sum2 = 0;
            for (int i = 0; i < len; i++) { sum1 += x % 10; x /= 10; }
            while (x > 0) { sum2 += x % 10; x /= 10; }

            return sum1 == sum2;
        }
    }
}
