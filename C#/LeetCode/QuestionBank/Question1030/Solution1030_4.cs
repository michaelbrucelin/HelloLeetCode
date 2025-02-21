using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1030
{
    public class Solution1030_4 : Interface1030
    {
        /// <summary>
        /// 纯手工向外一圈一圈的扩散，练习一下耐心和细心
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="rCenter"></param>
        /// <param name="cCenter"></param>
        /// <returns></returns>
        public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            int max = rCenter + cCenter;
            max = Math.Max(max, rCenter + cols - cCenter);
            max = Math.Max(max, rows - rCenter + cCenter);
            max = Math.Max(max, rows - rCenter + cols - cCenter);
            int[] dir = new int[] { -1, 1, 1, -1, -1 };
            bool[,] mask = new bool[rows, cols];
            int[][] result = new int[rows * cols][];
            result[0] = new int[] { rCenter, cCenter }; mask[rCenter, cCenter] = true;
            for (int i = 1, id = 1, r = 0, c = 0; i <= max; i++) for (int _r = 0, _c; _r <= i; _r++)
                {
                    _c = i - _r;
                    for (int j = 0; j < 4; j++)
                    {
                        r = rCenter + _r * dir[j]; c = cCenter + _c * dir[j + 1];
                        if (r >= 0 && r < rows && c >= 0 && c < cols && !mask[r, c])
                        {
                            result[id++] = new int[] { r, c }; mask[r, c] = true;
                        }
                    }
                }

            return result;
        }
    }
}
