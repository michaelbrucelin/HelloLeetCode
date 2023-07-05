using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1030
{
    public class Solution1030_2 : Interface1030
    {
        /// <summary>
        /// 类桶排序
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
            List<int[]>[] buckets = new List<int[]>[max + 1];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = new List<int[]>();
            for (int r = 0; r < rows; r++) for (int c = 0; c < cols; c++)
                {
                    buckets[Math.Abs(r - rCenter) + Math.Abs(c - cCenter)].Add(new int[] { r, c });
                }

            int[][] result = new int[rows * cols][];
            for (int i = 0, id = 0; i < buckets.Length; i++) for (int j = 0; j < buckets[i].Count; j++)
                {
                    result[id++] = buckets[i][j];
                }

            return result;
        }
    }
}
