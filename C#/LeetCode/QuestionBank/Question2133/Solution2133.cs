using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2133
{
    public class Solution2133 : Interface2133
    {
        /// <summary>
        /// Hash集合
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public bool CheckValid(int[][] matrix)
        {
            int n = matrix.Length;
            HashSet<int> set = new HashSet<int>();
            bool empty = true;

            // 验证每一行
            for (int r = 0; r < n; r++)
            {
                if (empty)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (set.Contains(matrix[r][c])) return false;   // 题目限定 1 <= matrix[r][x] <= n
                        set.Add(matrix[r][c]);
                    }
                }
                else
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (!set.Contains(matrix[r][c])) return false;  // 题目限定 1 <= matrix[r][x] <= n
                        set.Remove(matrix[r][c]);
                    }
                }
                empty = !empty;
            }

            // 验证每一列
            for (int c = 0; c < n; c++)
            {
                if (empty)
                {
                    for (int r = 0; r < n; r++)
                    {
                        if (set.Contains(matrix[r][c])) return false;   // 题目限定 1 <= matrix[r][x] <= n
                        set.Add(matrix[r][c]);
                    }
                }
                else
                {
                    for (int r = 0; r < n; r++)
                    {
                        if (!set.Contains(matrix[r][c])) return false;  // 题目限定 1 <= matrix[r][x] <= n
                        set.Remove(matrix[r][c]);
                    }
                }
                empty = !empty;
            }

            return true;
        }
    }
}
