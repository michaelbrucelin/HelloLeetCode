using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2352
{
    public class Solution2352 : Interface2352
    {
        /// <summary>
        /// 暴力枚举，O(n^3)
        /// 提交竟然过了，而且：时间：164 ms 击败 91.67%；内存：60.9 MB 击败 75%
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int EqualPairs(int[][] grid)
        {
            int result = 0, len = grid.Length, i;
            for (int r = 0; r < len; r++) for (int c = 0; c < len; c++)
                {
                    for (i = 0; i < len; i++) if (grid[r][i] != grid[i][c]) break;
                    if (i == len) result++;
                }

            return result;
        }
    }
}
