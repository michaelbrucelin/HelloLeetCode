using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1510
{
    public class Solution1510 : Interface1510
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool WinnerSquareGame(int n)
        {
            byte[] memory = new byte[n + 1];  // 1 true 2 false
            memory[0] = 2; memory[1] = 1;

            return dfs(n) == 1;

            int dfs(int x)
            {
                if (memory[x] != 0) return memory[x];

                int i = 1, y;
                memory[x] = 2;
                while ((y = x - i * i) >= 0)
                {
                    if (dfs(y) == 2) { memory[x] = 1; break; }
                    i++;
                }

                return memory[x];
            }
        }
    }
}
