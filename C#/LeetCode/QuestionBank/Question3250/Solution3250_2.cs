using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3250
{
    public class Solution3250_2 : Interface3250
    {
        /// <summary>
        /// DFS，有返回值
        /// 逻辑同Solution3250，改为有返回值版，为记忆化搜索做准备
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int len = nums.Length;
            return dfs(0, 0, nums[0]);

            int dfs(int id, int asc, int desc)
            {
                if (id == len) return 1;

                int result = 0;
                for (int i = asc, j = 0, sum = nums[id]; i <= sum; i++)
                {
                    j = sum - i;
                    if (j > desc) continue;
                    if (j < 0) break;
                    result += dfs(id + 1, i, j);
                    result %= MOD;
                }
                return result;
            }
        }
    }
}
