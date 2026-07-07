using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3756
{
    public class Solution3756_mle : Interface3756
    {
        /// <summary>
        /// 类前缀和，根据Solution3756_tle改进而来
        /// 记录[l, r]中非0数字和很简单，前缀和就可以
        /// 记录[l, r]中非0数字组合成的数字，不好办，这里先使用string来模拟，稍后再优化
        /// 
        /// MLE，逻辑没问题，MLE了，参考测试用例04
        /// </summary>
        /// <param name="s"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] SumAndMultiply(string s, int[][] queries)
        {
            int len = s.Length;
            int[] sums = new int[len + 1];
            string[] nums = new string[len + 1]; nums[0] = "";
            StringBuilder buffer = new StringBuilder();
            for (int i = 0, d; i < len; i++)
            {
                d = s[i] - '0';
                sums[i + 1] = sums[i] + d;
                if (d != 0) buffer.Append(d);
                nums[i + 1] = buffer.ToString();
            }

            len = queries.Length;
            const int MOD = (int)1e9 + 7;
            int[] result = new int[len];
            long num;
            for (int i = 0, l, r, sum; i < len; i++)
            {
                l = queries[i][0]; r = queries[i][1];
                if ((sum = sums[r + 1] - sums[l]) != 0)
                {
                    num = 0;
                    for (int j = nums[l].Length; j < nums[r + 1].Length; j++) num = (num * 10 + nums[r + 1][j] - '0') % MOD;
                    result[i] = (int)(num * sum % MOD);
                }
            }

            return result;
        }
    }
}
