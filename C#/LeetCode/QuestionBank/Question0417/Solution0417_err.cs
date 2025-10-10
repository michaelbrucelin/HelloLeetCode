using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0417
{
    public class Solution0417_err : Interface0417
    {
        /// <summary>
        /// DP
        /// DP处理出能到太平洋以及能到大西洋的点，再找交集
        /// DP处理能到太平洋的点的步骤
        /// 1. 上边与左边初始化为true
        /// 2. 从上向下逐行判断，每一行需要从左至右一轮，再从右至左一轮，总共扫描两轮
        /// 
        /// 逻辑错误，参考测试用例03的图示
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
            for (int r = 1; r < rcnt; r++)
            {
                for (int c = 1; c < ccnt; c++)
                {
                    if (heights[r][c] >= heights[r - 1][c] && dplt[r - 1, c]) dplt[r, c] = true;
                    if (heights[r][c] >= heights[r][c - 1] && dplt[r, c - 1]) dplt[r, c] = true;
                }
                for (int c = ccnt - 2; c > 0; c--)
                {
                    if (!dplt[r, c] && heights[r][c] >= heights[r][c + 1]) dplt[r, c] = dplt[r, c + 1];
                }
            }
            // 右边界与下边界
            for (int c = ccnt - 1; c >= 0; c--) dprb[rcnt - 1, c] = true;
            for (int r = rcnt - 1; r >= 0; r--) dprb[r, ccnt - 1] = true;
            for (int r = rcnt - 2; r >= 0; r--)
            {
                for (int c = ccnt - 2; c >= 0; c--)
                {
                    if (heights[r][c] >= heights[r + 1][c] && dprb[r + 1, c]) dprb[r, c] = true;
                    if (heights[r][c] >= heights[r][c + 1] && dprb[r, c + 1]) dprb[r, c] = true;
                }
                for (int c = 1; c < ccnt - 1; c++)
                {
                    if (!dprb[r, c] && heights[r][c] >= heights[r][c - 1]) dprb[r, c] = dprb[r, c - 1];
                }
            }

            List<IList<int>> result = new List<IList<int>>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (dplt[r, c] && dprb[r, c]) result.Add([r, c]);
            return result;
        }
    }
}
