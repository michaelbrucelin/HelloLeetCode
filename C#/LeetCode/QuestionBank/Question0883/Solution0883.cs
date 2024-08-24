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

        public int ProjectionArea3(int[][] grid)
        {
            int xy = 0;
            int[] xz = new int[50], yz = new int[50];
            for (int x = 0; x < grid.Length; x++) for (int y = 0; y < grid[x].Length; y++) if (grid[x][y] > 0)
                    {
                        xy++;
                        xz[x] = Math.Max(xz[x], grid[x][y]);
                        yz[y] = Math.Max(yz[y], grid[x][y]);
                    }

            return xy + xz.Sum() + yz.Sum();
        }
    }
}
