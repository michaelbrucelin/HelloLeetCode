using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2597
{
    public class Solution2597_err : Interface2597
    {
        /// <summary>
        /// 排列组合 + DP
        /// 1. 将nums分为如下k组，每组只有真实存在在nums中的元素，这里只是描述每组数据的规律
        ///     1   k+1   2k+1    ... mk+1
        ///     2   k+2   2k+2    ... mk+2
        ///     ...
        ///     k-1 k+k-1 2k+k-1  ... mk+k-1
        ///     这样，不同组之间可以任意组合，所以，只要计算每一组的美丽子集数量即可
        /// 2. 每组的计算可以使用DP，对于第m项
        ///     选择第m项，  那么m-1一定不选择
        ///     不选择第m项，那么m-1可以选择，也可以不选择
        ///     这部分可以使用矩阵快速幂来加速，但是题目的数据范围不大，就不这么做了
        ///     | F(N+1,0) |   | 0 1 |   | F(N-1,0) |
        ///     |          | = |     | * |          |
        ///     | F(N+1,1) |   | 1 1 |   | F(N-1,1) |
        /// 
        /// 也不算什么大错误，如果数组有重复项，上面dp的计算就有问题了，参考测试用例03
        /// 但是如果数组没有重复项，那么这个解法是正确的，就将这个结果保留下来
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int BeautifulSubsets(int[] nums, int k)
        {
            Array.Sort(nums);
            Dictionary<int, List<int>> grps = new Dictionary<int, List<int>>();
            int len = nums.Length;
            for (int i = 0, key = 0; i < len; i++)
            {
                key = nums[i] % k;
                if (grps.ContainsKey(key)) grps[key].Add(nums[i]); else grps.Add(key, new List<int>() { nums[i] });
            }

            int result = 1, cnt;
            int[,] dp;            // dp[i,0] 选择第i项，dp[i,1] 不选择第i项
            foreach (List<int> list in grps.Values)
            {
                if ((cnt = list.Count) == 1)
                {
                    result <<= 1;
                }
                else
                {
                    dp = new int[cnt, 2];
                    dp[0, 0] = dp[0, 1] = 1;
                    for (int i = 1; i < cnt; i++)
                    {
                        if (list[i] != list[i - 1] + k)
                        {
                            dp[i, 0] = dp[i, 1] = dp[i - 1, 0] + dp[i - 1, 1];
                        }
                        else
                        {
                            dp[i, 0] = dp[i - 1, 1];
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
