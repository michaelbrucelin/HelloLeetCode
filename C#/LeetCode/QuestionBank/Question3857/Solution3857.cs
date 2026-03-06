using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3857
{
    public class Solution3857 : Interface3857
    {
        /// <summary>
        /// 贪心 + 记忆化搜索
        /// 怎样证明？
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinCost(int n)
        {
            Dictionary<int, int> memory = new Dictionary<int, int>() { { 1, 0 }, { 2, 1 } };
            return dfs(n);

            int dfs(int x)
            {
                if (memory.TryGetValue(x, out int y)) return y;

                int half = x >> 1;
                if ((x & 1) == 0)
                {
                    memory.Add(x, half * half + (dfs(half) << 1));
                }
                else
                {
                    memory.Add(x, half * (half + 1) + dfs(half) + dfs(half + 1));
                }

                return memory[x];
            }
        }
    }
}
