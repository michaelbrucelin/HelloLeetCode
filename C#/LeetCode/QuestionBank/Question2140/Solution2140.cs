using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2140
{
    public class Solution2140 : Interface2140
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public long MostPoints(int[][] questions)
        {
            int len = questions.Length;
            Dictionary<int, long> memory = new Dictionary<int, long>();
            return dfs(0);

            long dfs(int i)
            {
                if (i >= len) return 0;
                if (memory.ContainsKey(i)) return memory[i];

                long yes = questions[i][0] + dfs(i + questions[i][1] + 1);
                long no = dfs(i + 1);
                memory[i] = Math.Max(yes, no);

                return memory[i];
            }
        }
    }
}
