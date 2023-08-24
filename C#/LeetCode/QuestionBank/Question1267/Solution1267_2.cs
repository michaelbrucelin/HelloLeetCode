using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1267
{
    public class Solution1267_2 : Interface1267
    {
        /// <summary>
        /// 两次遍历
        /// 1. 第1次遍历，统计出grid每一行每一列有多少个1
        /// 2. 第2值遍历，统计结果
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountServers(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int[] rset = new int[ccnt], cset = new int[rcnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 1) { rset[c]++; cset[r]++; }
                }
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (grid[r][c] == 1 && (rset[c] > 1 || cset[r] > 1)) result++;
                }

            return result;
        }
    }
}
