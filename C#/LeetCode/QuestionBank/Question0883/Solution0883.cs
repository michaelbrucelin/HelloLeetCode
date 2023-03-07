using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0883
{
    public class Solution0883 : Interface0883
    {
        /// <summary>
        /// 分析
        /// xy(z面)投影，有几处有值（>0）,投影就是多少
        /// yz(x面)投影，相同x取最大值，即每一行的最大值
        /// zx(y面)投影，相同y取最大值，即每一列的最大值
        /// 上面描述的行与列可以互换，就看你怎么看，反正一行一列就对了
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ProjectionArea(int[][] grid)
        {
            int result = 0, len = grid.Length;
            for (int i = 0; i < len; i++) for (int j = 0; j < len; j++) if (grid[i][j] > 0) result++;
            for (int i = 0, max = 0; i < len; i++, result += max, max = 0) for (int j = 0; j < len; j++) if (grid[i][j] > max) max = grid[i][j];
            for (int i = 0, max = 0; i < len; i++, result += max, max = 0) for (int j = 0; j < len; j++) if (grid[j][i] > max) max = grid[j][i];

            return result;
        }

        public int ProjectionArea2(int[][] grid)
        {
            int result = 0, len = grid.Length;
            for (int i = 0, _yz = 0, _zx = 0; i < len; i++, result += (_yz + _zx), _yz = 0, _zx = 0) for (int j = 0; j < len; j++)
                {
                    if (grid[i][j] > 0) result++;
                    if (grid[i][j] > _yz) _yz = grid[i][j];
                    if (grid[j][i] > _zx) _zx = grid[j][i];
                }

            return result;
        }

        /// <summary>
        /// Linq
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ProjectionArea3(int[][] grid)
        {
            //int r1 = grid.Sum(row => row.Count(i => i > 0));
            //int r2 = grid.Sum(row => row.Max());
            //int r3 = grid.Aggregate((row1, row2) => Enumerable.Range(0, grid.Length).Select(i => Math.Max(row1[i], row2[i])).ToArray()).Sum();
            return grid.Sum(row => row.Count(i => i > 0) + row.Max())
                   + grid.Aggregate((row1, row2) => Enumerable.Range(0, grid.Length)
                                                              .Select(i => Math.Max(row1[i], row2[i])).ToArray())
                         .Sum();
        }
    }
}
