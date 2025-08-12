using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2787
{
    public class Solution2787 : Interface2787
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int NumberOfWays(int n, int x)
        {
            List<int> list = new List<int>();
            if (x == 1)
            {
                for (int i = 1; i <= n; i++) list.Add(i);
            }
            else
            {
                for (int i = 1, j; i <= n; i++)
                {
                    j = (int)Math.Pow(i, x);
                    if (j <= n) list.Add(j); else break;
                }
            }

            const int MOD = (int)1e9 + 7;
            int len = list.Count;
            Dictionary<(int start, int target), int> memory = new Dictionary<(int start, int target), int>();
            return dfs(0, n);

            int dfs(int start, int target)
            {
                if (target == 0) return 1;
                if (start >= len || list[start] > target) return 0;
                if (!memory.ContainsKey((start, target)))
                {
                    memory.Add((start, target), (dfs(start + 1, target) + dfs(start + 1, target - list[start])) % MOD);
                }
                return memory[(start, target)];
            }
        }

        /// <summary>
        /// 逻辑与NumberOfWays()相同，将字典改为数组
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int NumberOfWays2(int n, int x)
        {
            List<int> list = new List<int>();
            if (x == 1)
            {
                for (int i = 1; i <= n; i++) list.Add(i);
            }
            else
            {
                for (int i = 1, j; i <= n; i++)
                {
                    j = (int)Math.Pow(i, x);
                    if (j <= n) list.Add(j); else break;
                }
            }

            const int MOD = (int)1e9 + 7;
            int len = list.Count;
            int[,] memory = new int[len, n + 1];
            for (int i = 0; i < len; i++) for (int j = 0; j <= n; j++) memory[i, j] = -1;
            return dfs(0, n);

            int dfs(int start, int target)
            {
                if (target == 0) return 1;
                if (start >= len || list[start] > target) return 0;
                if (memory[start, target] == -1)
                {
                    memory[start, target] = (dfs(start + 1, target) + dfs(start + 1, target - list[start])) % MOD;
                }
                return memory[start, target];
            }
        }
    }
}
