using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2267
{
    public class Solution2267 : Interface2267
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool HasValidPath(char[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            if (((rcnt + ccnt) & 1) == 0 || grid[0][0] == ')' || grid[^1][^1] == '(') return false;
            byte[,,] memory = new byte[rcnt, ccnt, (rcnt + ccnt + 1) >> 1];  // 1 true, 2 false
            return dfs(0, 0, 0);

            bool dfs(int r, int c, int lcnt)
            {
                if (memory[r, c, lcnt] != 0) return memory[r, c, lcnt] == 1;
                if (r == rcnt - 1 && c == ccnt - 1) return lcnt == 1 && grid[^1][^1] == ')';

                memory[r, c, lcnt] = 2;
                lcnt += grid[r][c] == '(' ? 1 : -1;
                if (lcnt < 0) return false;
                if (rcnt - r + ccnt - c - 2 < lcnt) return false;
                if (r + 1 < rcnt && dfs(r + 1, c, lcnt)) { memory[r, c, lcnt] = 1; return true; }
                if (c + 1 < ccnt && dfs(r, c + 1, lcnt)) { memory[r, c, lcnt] = 1; return true; }

                return false;
            }
        }
    }
}
