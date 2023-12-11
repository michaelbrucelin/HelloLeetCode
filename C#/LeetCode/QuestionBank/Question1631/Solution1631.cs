using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1631
{
    public class Solution1631 : Interface1631
    {
        private static readonly int[] dirs = new int[] { -1, 0, 1, 0, -1 };

        /// <summary>
        /// DFS
        /// 会很慢，而且内存占用会很大
        /// 
        /// TLE，参考测试用例04
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int MinimumEffortPath(int[][] heights)
        {
            int rcnt = heights.Length, ccnt = heights[0].Length;
            bool[,] visited = new bool[rcnt, ccnt];

            return dfs(heights, rcnt, ccnt, 0, 0, visited);
        }

        private int dfs(int[][] heights, int rcnt, int ccnt, int r, int c, bool[,] visited)
        {
            if (r == rcnt - 1 && c == ccnt - 1) return 0;

            int result = int.MaxValue;
            visited[r, c] = true;
            for (int i = 0, _r, _c, _result; i < 4; i++)
            {
                _r = r + dirs[i]; _c = c + dirs[i + 1];
                if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && !visited[_r, _c])
                {
                    bool[,] _visited = (bool[,])visited.Clone();
                    _result = Math.Max(Math.Abs(heights[_r][_c] - heights[r][c]), dfs(heights, rcnt, ccnt, _r, _c, _visited));
                    result = Math.Min(result, _result);
                }
            }

            return result;
        }
    }
}
