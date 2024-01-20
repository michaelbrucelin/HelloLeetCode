using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2748
{
    public class Solution2748 : Interface2748
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountBeautifulPairs(int[] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0, x; i < len - 1; i++)
            {
                x = FirstDigit(nums[i]);
                for (int j = i + 1; j < len; j++)
                    if (IsCoprime(x, nums[j] % 10)) result++;
            }

            return result;
        }

        private bool IsCoprime(int x, int y)
        {
            if (x == y) return x == 1;

            while (x != y)
            {
                switch ((x & 1, y & 1))
                {
                    case (0, 0): return false;
                    case (0, 1): x >>= 1; break;
                    case (1, 0): y >>= 1; break;
                    default:  // (1, 1)
                        if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                        break;
                }
            }

            return x == 1;
        }

        private int FirstDigit(int x)
        {
            while (x > 9) x /= 10;
            return x;
        }
    }
}
