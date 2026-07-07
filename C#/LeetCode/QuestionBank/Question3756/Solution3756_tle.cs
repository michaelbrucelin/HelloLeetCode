using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3756
{
    public class Solution3756_tle : Interface3756
    {
        /// <summary>
        /// 类前缀和
        /// 记录[l, r]中非0数字和很简单，前缀和就可以
        /// 记录[l, r]中非0数字组合成的数字，不好办，这里先使用BigInteger来模拟，稍后再优化
        /// 
        /// TLE，逻辑没问题，超时了，参考测试用例04，问题大概率出现在BigInteger上面
        /// </summary>
        /// <param name="s"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] SumAndMultiply(string s, int[][] queries)
        {
            int len = s.Length;
            int[] sums = new int[len + 1];
            BigInteger[,] nums = new BigInteger[len + 1, 2];
            nums[0, 0] = 0; nums[0, 1] = 1;
            for (int i = 0, d; i < len; i++)
            {
                d = s[i] - '0';
                sums[i + 1] = sums[i] + d;
                if (d != 0)
                {
                    nums[i + 1, 0] = nums[i, 0] * 10 + d;
                    nums[i + 1, 1] = nums[i, 1] * 10;
                }
                else
                {
                    nums[i + 1, 0] = nums[i, 0];
                    nums[i + 1, 1] = nums[i, 1];
                }
            }

            len = queries.Length;
            const int MOD = (int)1e9 + 7;
            int[] result = new int[len];
            for (int i = 0, l, r, num, sum; i < len; i++)
            {
                l = queries[i][0]; r = queries[i][1];
                if ((sum = sums[r + 1] - sums[l]) != 0)
                {
                    num = (int)((nums[r + 1, 0] - nums[l, 0] * (nums[r + 1, 1] / nums[l, 1])) % MOD);
                    result[i] = (int)(1L * num * sum % MOD);
                }
            }

            return result;
        }
    }
}
