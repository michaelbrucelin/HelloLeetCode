using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1351
{
    public class Solution1351_3 : Interface1351
    {
        /// <summary>
        /// 行倒序，列正序遍历
        /// 即从左下角向右上角遍历
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountNegatives(int[][] grid)
        {
            int result = 0, rcnt = grid.Length, ccnt = grid[0].Length;
            int pr = rcnt - 1, pc = 0;
            while (pr >= 0 && pc < ccnt)
            {
                while (pc < ccnt && grid[pr][pc] >= 0) pc++;
                result += ccnt - pc;
                pr--;
            }

            return result;
        }
    }
}
