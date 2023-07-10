using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1351
{
    public class Solution1351 : Interface1351
    {
        /// <summary>
        /// 倒序遍历
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountNegatives(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length - 1;
            for (int r = 0, c = ccnt; r < rcnt; r++)
            {
                result += ccnt - c;
                for (; c >= 0 && grid[r][c] < 0; c--) result++;
            }

            return result;
        }
    }
}
