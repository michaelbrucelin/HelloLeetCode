using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2373
{
    public class Solution2373 : Interface2373
    {
        /// <summary>
        /// 暴力解
        /// 忽略时间复杂度，代码看起来还挺优雅，写着玩
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] LargestLocal(int[][] grid)
        {
            int len = grid.Length;
            int[][] result = new int[len - 2][];
            for (int i = 0; i < len - 2; i++) result[i] = new int[len - 2];
            for (int r = 0; r < len - 2; r++) for (int c = 0, val = -1; c < len - 2; c++, val = -1)
                {
                    for (int _r = 0; _r < 3; _r++) for (int _c = 0; _c < 3; _c++)
                        {
                            val = Math.Max(val, grid[r + _r][c + _c]);
                        }
                    result[r][c] = val;
                }

            return result;
        }

        /// <summary>
        /// API
        /// 纯粹练练Linq的用法
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] LargestLocal2(int[][] grid)
        {
            int len = grid.Length;
            var query = Enumerable.Range(0, len - 2)
                       .Select(r => (r, Enumerable.Range(0, len - 2)))
                       .Select(item => item.Item2.Select(c => grid.Skip(item.r).Take(3).Select(row => row.Skip(c).Take(3).Max()).Max()).ToArray())
                       .ToArray();

            return query;
        }
    }
}
