using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1605
{
    public class Solution1605 : Interface1605
    {
        /// <summary>
        /// 贪心
        /// 具体见Solution1605.md
        /// </summary>
        /// <param name="rowSum"></param>
        /// <param name="colSum"></param>
        /// <returns></returns>
        public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
        {
            int rows = rowSum.Length, cols = colSum.Length;
            int[][] result = new int[rows][];
            for (int r = 0; r < rows; r++) result[r] = new int[cols];

            for (int c = 0; c < cols; c++) result[0][c] = colSum[c];
            for (int r = 0, _sum, sum; r < rows - 1; r++)
            {
                _sum = 0; sum = rowSum[r];
                for (int c = 0; c < cols; c++)
                {
                    if (_sum < sum)
                    {
                        if (_sum + result[r][c] <= sum) _sum += result[r][c];
                        else
                        {
                            result[r + 1][c] = _sum + result[r][c] - sum; result[r][c] = sum - _sum; _sum = sum;
                        }
                    }
                    else  // _sum == sum
                    {
                        result[r + 1][c] = result[r][c]; result[r][c] = 0;
                    }
                }
            }

            return result;
        }
    }
}
