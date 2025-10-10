using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0417
{
    public class Solution0417 : Interface0417
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution0417_err，增加扫描
        /// 
        /// 应该可以修正，先不弄了，DFS与BFS也能解决，先不写了
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int rcnt = heights.Length, ccnt = heights[0].Length;
            bool[,] dplt = new bool[rcnt, ccnt], dprb = new bool[rcnt, ccnt];
            // 左边界与上边界
            for (int c = 0; c < ccnt; c++) dplt[0, c] = true;
            for (int r = 1; r < rcnt; r++) dplt[r, 0] = true;
            for (int r = 1; r < rcnt; r++) for (int c = 1; c < ccnt; c++)
                {
                    if (heights[r][c] >= heights[r - 1][c] && dplt[r - 1, c]) dplt[r, c] = true;
                    if (heights[r][c] >= heights[r][c - 1] && dplt[r, c - 1]) dplt[r, c] = true;
                }
            for (int r = 1; r < rcnt; r++) for (int c = ccnt - 2; c > 0; c--)
                {
                    if (!dplt[r, c] && heights[r][c] >= heights[r][c + 1]) dplt[r, c] = dplt[r, c + 1];
                }
            for (int c = 1; c < ccnt; c++) for (int r = rcnt - 2; r > 0; r--)
                {
                    if (!dplt[r, c] && heights[r][c] >= heights[r + 1][c]) dplt[r, c] = dplt[r + 1, c];
                }
            // 右边界与下边界
            for (int c = ccnt - 1; c >= 0; c--) dprb[rcnt - 1, c] = true;
            for (int r = rcnt - 1; r >= 0; r--) dprb[r, ccnt - 1] = true;
            for (int r = rcnt - 2; r >= 0; r--) for (int c = ccnt - 2; c >= 0; c--)
                {
                    if (heights[r][c] >= heights[r + 1][c] && dprb[r + 1, c]) dprb[r, c] = true;
                    if (heights[r][c] >= heights[r][c + 1] && dprb[r, c + 1]) dprb[r, c] = true;
                }
            for (int r = rcnt - 2; r >= 0; r--) for (int c = 1; c < ccnt - 1; c++)
                {
                    if (!dprb[r, c] && heights[r][c] >= heights[r][c - 1]) dprb[r, c] = dprb[r, c - 1];
                }
            for (int c = ccnt - 2; c >= 0; c--) for (int r = 1; r < rcnt - 1; r++)
                {
                    if (!dprb[r, c] && heights[r][c] >= heights[r - 1][c]) dprb[r, c] = dprb[r - 1, c];
                }

            List<IList<int>> result = new List<IList<int>>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (dplt[r, c] && dprb[r, c]) result.Add([r, c]);
            return result;
        }
    }
}
