using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0811
{
    public class Solution0811_err : Interface0811
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 
        /// 题目求的是组合数，这里求的是排列数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int WaysToChange(int n)
        {
            const int MOD = (int)1e9 + 7;
            int[] memory = new int[n + 1];
            return dfs(n);

            int dfs(int n)
            {
                if (n < 5) return 1;
                if (memory[n] != 0) return memory[n];

                int cnt = 0;
                if (n >= 25) cnt = (cnt + dfs(n - 25)) % MOD;
                if (n >= 10) cnt = (cnt + dfs(n - 10)) % MOD;
                if (n >= 05) cnt = (cnt + dfs(n - 05)) % MOD;
                cnt = (cnt + dfs(n - 1)) % MOD;
                memory[n] = cnt;
                return cnt;
            }
        }
    }
}
