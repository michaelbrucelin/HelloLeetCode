using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2447
{
    public class Solution2447 : Interface2447
    {
        /// <summary>
        /// 暴力查找
        /// 长度为n的子数组的gcd由两个长度为n-1的子数组的gcd O(1)计算
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarrayGCD(int[] nums, int k)
        {
            int result = 0, span = 1, len = nums.Length;
            int[] cache = new int[len];
            for (int i = 0; i < len; i++) if ((cache[i] = nums[i]) == k) result++;
            while (++span <= len) for (int l = 0, r = span - 1; r < len; l++, r++)
                {
                    cache[l] = GetGCD(cache[l], cache[l + 1]);
                    if (cache[l] == k) result++;
                }

            return result;

            static int GetGCD(int x, int y)
            {
                if (x == y) return x;

                int move = 0;
                while (x != y) switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }

                return x << move;
            }
        }
    }
}
