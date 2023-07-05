using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1030
{
    public class Solution1030 : Interface1030
    {
        /// <summary>
        /// 排序
        /// 罗列全部的坐标，然后排序
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="rCenter"></param>
        /// <param name="cCenter"></param>
        /// <returns></returns>
        public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            int[][] result = new int[rows * cols][];
            int id = 0;
            for (int r = 0; r < rows; r++) for (int c = 0; c < cols; c++)
                {
                    result[id++] = new int[] { r, c };
                }
            Array.Sort(result, (arr1, arr2) => Math.Abs(arr1[0] - rCenter) + Math.Abs(arr1[1] - cCenter) - Math.Abs(arr2[0] - rCenter) - Math.Abs(arr2[1] - cCenter));

            return result;
        }
    }
}
