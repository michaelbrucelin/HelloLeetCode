using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3250
{
    public class Solution3250_4 : Interface3250
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 逻辑同Solution3250_3，将字典改为数组，为DP做准备
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int max = nums.Max(), len = nums.Length;
            int[,,] memory = new int[len, max + 1, max + 1];
            for (int i = 0; i < len; i++) for (int j = 0; j <= max; j++) for (int k = 0; k <= max; k++) memory[i, j, k] = -1;
            return dfs(0, 0, nums[0]);

            int dfs(int id, int asc, int desc)
            {
                if (id == len) return 1;
                if (memory[id, asc, desc] == -1)
                {
                    int result = 0;
                    for (int i = asc, j = 0, sum = nums[id]; i <= sum; i++)
                    {
                        j = sum - i;
                        if (j > desc) continue;
                        if (j < 0) break;
                        result += dfs(id + 1, i, j);
                        result %= MOD;
                    }
                    memory[id, asc, desc] = result;
                }

                return memory[id, asc, desc];
            }
        }

        /// <summary>
        /// 逻辑同CountOfPairs()，memory可以是2维数组，第3维是没有意义的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs2(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int max = nums.Max(), len = nums.Length;
            int[,] memory = new int[len, max + 1];
            for (int i = 0; i < len; i++) for (int j = 0; j <= max; j++) memory[i, j] = -1;
            return dfs(0, 0, nums[0]);

            int dfs(int id, int asc, int desc)
            {
                if (id == len) return 1;
                if (memory[id, asc] == -1)
                {
                    int result = 0;
                    for (int i = asc, j = 0, sum = nums[id]; i <= sum; i++)
                    {
                        j = sum - i;
                        if (j > desc) continue;
                        if (j < 0) break;
                        result += dfs(id + 1, i, j);
                        result %= MOD;
                    }
                    memory[id, asc] = result;
                }

                return memory[id, asc];
            }
        }
    }
}
