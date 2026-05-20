using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3091
{
    public class Solution3091 : Interface3091
    {
        /// <summary>
        /// 数学 + 二分
        /// 1. 问题可以转换成操作n次可以达到的最大的和，然后二分找和达到k的最少操作次数
        /// 2. 操作n次，所有加1的操作一定在前，所有复制的操作一定在后（反证法轻松证明）
        /// 3. 假设加1操作了x次，那么复制了n-x次，则总和为(x+1)(n-x+1)，显然，x = n/2 时和最大
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations(int k)
        {
            if (k < 4) return k - 1;

            int result = k, low = 0, high = k, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                // if (((mid >> 1) + 1) * (mid - (mid >> 1) + 1) >= k)
                if (((mid >> 1) + 1) * (((mid + 1) >> 1) + 1) >= k)
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }

        /// <summary>
        /// 数学
        /// 逻辑与MinOperations()完全相同，相当于MinOperations()逆操作，直接计算结果
        /// 解(n/2+1)(n/2+1)>=k即可，解得 n >= Sqrt(k) * 2 - 2
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations2(int k)
        {
            if (k < 4) return k - 1;
            int result = (int)Math.Ceiling(Math.Sqrt(k)) * 2 - 3;
            if (((result >> 1) + 1) * (((result + 1) >> 1) + 1) >= k) return result;
            return result + 1;
        }
    }
}
