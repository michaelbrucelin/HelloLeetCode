using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1376
{
    public class Solution1376_3 : Interface1376
    {
        /// <summary>
        /// DFS + 记忆化
        /// 自底向上DFS，记忆化搜索，这样的好处是不需要先转成树（图）
        /// </summary>
        /// <param name="n"></param>
        /// <param name="headID"></param>
        /// <param name="manager"></param>
        /// <param name="informTime"></param>
        /// <returns></returns>
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            Dictionary<int, int> memory = new Dictionary<int, int>();

            int result = 0;
            for (int i = 0; i < n; i++) result = Math.Max(result, dfs(i, manager, informTime, memory));

            return result;
        }

        private int dfs(int headID, int[] manager, int[] informTime, Dictionary<int, int> memory)
        {
            if (manager[headID] == -1) return informTime[headID];
            if (memory.ContainsKey(headID)) return memory[headID];

            int result = informTime[headID] + dfs(manager[headID], manager, informTime, memory);
            memory.TryAdd(headID, result);

            return result;
        }
    }
}
