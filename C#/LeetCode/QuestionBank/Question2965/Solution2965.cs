using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2965
{
    public class Solution2965 : Interface2965
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] FindMissingAndRepeatedValues(int[][] grid)
        {
            int[] result = new int[2];
            int id, n = grid.Length;
            bool[] record = new bool[n * n];
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                {
                    if (record[id = grid[r][c] - 1]) result[0] = grid[r][c]; else record[id] = true;
                }
            for (int i = 0; i < n * n; i++) if (!record[i])
                {
                    result[1] = i + 1; break;
                }

            return result;
        }
    }
}
