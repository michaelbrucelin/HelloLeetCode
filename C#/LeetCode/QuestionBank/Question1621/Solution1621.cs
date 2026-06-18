using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1621
{
    public class Solution1621 : Interface1621
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfSets(int n, int k)
        {
            if (k == n - 1) return 1;

            const int MOD = (int)1e9 + 7;
            int[,] memory = new int[n, k + 1];
            for (int i = 0; i < n; i++) for (int j = 0; j <= k; j++) memory[i, j] = -1;
            return dfs(n - 1, k);

            int dfs(int n, int k)
            {
                if (k == 0 || k == n) return 1;
                if (memory[n, k] != -1) return memory[n, k];

                int result = dfs(n - 1, k);
                for (int i = 1; n - i >= k - 1; i++) result = (result + dfs(n - i, k - 1)) % MOD;
                memory[n, k] = result;
                return result;
            }
        }
    }
}
