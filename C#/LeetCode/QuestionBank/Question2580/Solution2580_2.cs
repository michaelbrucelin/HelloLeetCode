using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2580
{
    public class Solution2580_2 : Interface2580
    {
        /// <summary>
        /// 排序 + 排列组合
        /// 逻辑与Solution2580一样，做了下面两点优化
        /// 1. 排序，直接计数共多少个组
        /// 2. 排列组合，Cn0 + Cn1 + ... + Cnn = 2^n，快速幂计算2^n
        /// </summary>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public int CountWays(int[][] ranges)
        {
            const int MOD = (int)1e9 + 7;
            Comparer<int[]> comparer = Comparer<int[]>.Create((arr1, arr2) => (arr1[0] - arr2[0]) switch { > 0 => 1, < 0 => -1, _ => (arr1[1] - arr2[1]) switch { > 0 => 1, < 0 => -1, _ => 0 } });
            Array.Sort(ranges, comparer);

            int cnt = 1; int[] last = ranges[0].ToArray();
            for (int i = 1; i < ranges.Length; i++)
            {
                if (ranges[i][0] <= last[1])
                {
                    last[1] = Math.Max(last[1], ranges[i][1]);
                }
                else
                {
                    cnt++; last = ranges[i].ToArray();
                }
            }

            long result = 1, pow = 2;
            while (cnt > 0)
            {
                if ((cnt & 1) == 1) result = result * pow % MOD;
                pow = pow * pow % MOD;
                cnt >>= 1;
            }

            return (int)result;
        }
    }
}
