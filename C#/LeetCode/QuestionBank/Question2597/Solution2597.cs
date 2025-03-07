using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2597
{
    public class Solution2597 : Interface2597
    {
        /// <summary>
        /// 排列组合 + DP
        /// 逻辑同Solution2597_err，修复了数组中有重复元素（TestCase03）时的错误
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int BeautifulSubsets(int[] nums, int k)
        {
            Array.Sort(nums);
            Dictionary<int, List<int>> grps = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> cnts = new Dictionary<int, List<int>>();
            int len = nums.Length;
            for (int i = 0, num = 0, key = 0; i < len; i++)
            {
                key = (num = nums[i]) % k;
                if (grps.ContainsKey(key))
                {
                    if (grps[key][^1] == num)
                    {
                        cnts[key][^1]++;
                    }
                    else
                    {
                        grps[key].Add(num); cnts[key].Add(1);
                    }
                }
                else
                {
                    grps.Add(key, new List<int>() { num });
                    cnts.Add(key, new List<int>() { 1 });
                }
            }

            int result = 1, cnt;
            int[,] dp;            // dp[i,0] 选择第i项，dp[i,1] 不选择第i项
            foreach (int key in grps.Keys)
            {
                if ((cnt = grps[key].Count) == 1)
                {
                    result *= 1 << cnts[key][0];
                }
                else
                {
                    dp = new int[cnt, 2];
                    dp[0, 0] = (1 << cnts[key][0]) - 1;
                    dp[0, 1] = 1;
                    for (int i = 1; i < cnt; i++)
                    {
                        if (grps[key][i] != grps[key][i - 1] + k)
                        {
                            dp[i, 0] = (dp[i - 1, 0] + dp[i - 1, 1]) * ((1 << cnts[key][i]) - 1);
                            dp[i, 1] = dp[i - 1, 0] + dp[i - 1, 1];
                        }
                        else
                        {
                            dp[i, 0] = dp[i - 1, 1] * ((1 << cnts[key][i]) - 1);
                            dp[i, 1] = dp[i - 1, 0] + dp[i - 1, 1];
                        }
                    }
                    result *= dp[cnt - 1, 0] + dp[cnt - 1, 1];
                }
            }

            return result - 1;
        }
    }
}
