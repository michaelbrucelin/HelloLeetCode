using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1030
{
    public class Solution1030_3 : Interface1030
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="rCenter"></param>
        /// <param name="cCenter"></param>
        /// <returns></returns>
        public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            List<int[]> result = new List<int[]>();
            int[] dir = new int[] { -1, 0, 1, 0, -1 };
            bool[,] mask = new bool[rows, cols];
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { rCenter, cCenter }); mask[rCenter, cCenter] = true;
            int cnt; int[] arr; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    arr = queue.Dequeue();
                    result.Add(arr);
                    for (int j = 0; j < 4; j++)
                    {
                        int r = arr[0] + dir[j], c = arr[1] + dir[j + 1];
                        if (r >= 0 && r < rows && c >= 0 && c < cols && !mask[r, c])
                        {
                            queue.Enqueue(new int[] { r, c }); mask[r, c] = true;
                        }
                    }
                }
            }

            return result.ToArray();
        }
    }
}
