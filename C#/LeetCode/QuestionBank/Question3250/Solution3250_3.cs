﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3250
{
    public class Solution3250_3 : Interface3250
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 逻辑同Solution3250_2，增加记忆化搜索
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int len = nums.Length;
            Dictionary<(int id, int asc, int desc), int> memory = new Dictionary<(int id, int asc, int desc), int>();
            return dfs(0, 0, nums[0]);

            int dfs(int id, int asc, int desc)
            {
                if (id == len) return 1;
                if (!memory.ContainsKey((id, asc, desc)))
                {
                    int result = 0;
                    for (int i = asc, j, sum = nums[id]; i <= sum; i++)
                    {
                        j = sum - i;
                        if (j > desc) continue;
                        if (j < 0) break;
                        result += dfs(id + 1, i, j);
                        result %= MOD;
                    }
                    memory.Add((id, asc, desc), result);
                }

                return memory[(id, asc, desc)];
            }
        }

        /// <summary>
        /// 逻辑同CountOfPairs()，memory的键是二元的就可以
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs2(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int len = nums.Length;
            Dictionary<(int id, int asc), int> memory = new Dictionary<(int id, int asc), int>();
            return dfs(0, 0, nums[0]);

            int dfs(int id, int asc, int desc)
            {
                if (id == len) return 1;
                if (!memory.ContainsKey((id, asc)))
                {
                    int result = 0;
                    for (int i = asc, j, sum = nums[id]; i <= sum; i++)
                    {
                        j = sum - i;
                        if (j > desc) continue;
                        if (j < 0) break;
                        result += dfs(id + 1, i, j);
                        result %= MOD;
                    }
                    memory.Add((id, asc), result);
                }

                return memory[(id, asc)];
            }
        }
    }
}