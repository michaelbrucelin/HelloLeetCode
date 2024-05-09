using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3127
{
    public class Solution3127 : Interface3127
    {
        /// <summary>
        /// 暴力查找
        /// 可以优化为滑动窗口，这里就不实操了。
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool CanMakeSquare(char[][] grid)
        {
            int[] mask = new int[2];
            for (int r = 0; r < 2; r++) for (int c = 0; c < 2; c++)
                {
                    mask[0] = 0; mask[1] = 0;
                    for (int _r = 0; _r < 2; _r++) for (int _c = 0; _c < 2; _c++) mask[grid[r + _r][c + _c] & 1]++;
                    if (mask[0] <= 1 || mask[1] <= 1) return true;
                }

            return false;
        }
    }
}
