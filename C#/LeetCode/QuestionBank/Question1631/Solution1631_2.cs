using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1631
{
    public class Solution1631_2 : Interface1631
    {
        private static readonly int[] dirs = new int[] { -1, 0, 1, 0, -1 };

        /// <summary>
        /// 回溯
        /// 逻辑同Solution1631，但是这里使用回溯，时间复杂度同Solution1631，所以依然会TLE
        /// 但是回溯会节省很多内存，因为不需要记录众多的visited数组，这里只是作为练习写着玩的
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
                    _result = Math.Max(Math.Abs(heights[_r][_c] - heights[r][c]), dfs(heights, rcnt, ccnt, _r, _c, visited));
                    result = Math.Min(result, _result);
                }
            }
            visited[r, c] = false;

            return result;
        }
    }
}
