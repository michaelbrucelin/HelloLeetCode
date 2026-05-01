using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3742
{
    public class Solution3742 : Interface3742
    {
        /// <summary>
        /// DFS
        /// 意料之中的TLE，参考测试用例05
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxPathScore(int[][] grid, int k)
        {
            // if (k == 0) return 0;  // 需要考虑路径中是否全部为0
            int rcnt = grid.Length, ccnt = grid[0].Length;
            return dfs(0, 0, k);

            int dfs(int r, int c, int k)
            {
                if (r >= rcnt || c >= ccnt) return -1;
                if (k < Math.Sign(grid[r][c])) return -1;
                if (r == rcnt - 1 && c == ccnt - 1) return grid[r][c];

                k -= Math.Sign(grid[r][c]);
                int score = Math.Max(dfs(r + 1, c, k), dfs(r, c + 1, k));
                if (score == -1) return -1;
                return grid[r][c] + score;
            }
        }

        /// <summary>
        /// DFS + 记忆化搜索
        /// 依然TLE，参考测试用例06，时间复杂度原则上与DP相同，难不成慢在Hash上了？
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxPathScore2(int[][] grid, int k)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            Dictionary<(int, int, int), int> memory = new Dictionary<(int, int, int), int>();
            return dfs(0, 0, k);

            int dfs(int r, int c, int k)
            {
                if (memory.ContainsKey((r, c, k))) return memory[(r, c, k)];
                if (r >= rcnt || c >= ccnt) return -1;
                if (k < Math.Sign(grid[r][c])) return -1;
                if (r == rcnt - 1 && c == ccnt - 1) { memory[(r, c, k)] = grid[r][c]; return grid[r][c]; }

                int _k = k - Math.Sign(grid[r][c]);
                int score = Math.Max(dfs(r + 1, c, _k), dfs(r, c + 1, _k));
                if (score == -1) { memory[(r, c, k)] = -1; return -1; }
                memory[(r, c, k)] = grid[r][c] + score;
                return grid[r][c] + score;
            }
        }
    }
}
