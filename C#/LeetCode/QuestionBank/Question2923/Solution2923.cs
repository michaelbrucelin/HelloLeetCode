using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2923
{
    public class Solution2923 : Interface2923
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int FindChampion(int[][] grid)
        {
            int n = grid.Length;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++) if (c != r && grid[r][c] != 1) goto CONTINU;
                return r;
                CONTINU:;
            }

            return -1;
        }

        /// <summary>
        /// 暴力枚举
        /// 逻辑同FindChampion()，做了剪枝优化，当检查到第r行的第c列，发现队伍r弱于队伍c，
        /// 那么下一次直接从第c行的第c+1列继续检查即可
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int FindChampion2(int[][] grid)
        {
            int n = grid.Length, r = 0, c = 1;
            for (; r < n;)
            {
                for (; c < n; c++) if (grid[r][c] != 1)
                    {
                        r = c; c = c + 1; goto CONTINU;
                    }
                return r;
                CONTINU:;
            }

            return -1;
        }
    }
}
