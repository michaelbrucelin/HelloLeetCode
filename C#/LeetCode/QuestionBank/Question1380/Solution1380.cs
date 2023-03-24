using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1380
{
    public class Solution1380 : Interface1380
    {
        /// <summary>
        /// 暴力解
        /// 1. 找出每一行的最小值，记录索引
        /// 2. 找出每一列的最大值，记录索引
        /// 3. 上面两组数据找交叉的数据，记录结果
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            int rows = matrix.Length, cols = matrix[0].Length, index;
            int[] r_min = new int[rows], c_max = new int[cols];
            for (int r = 0; r < rows; r++)
            {
                index = 0;
                for (int c = 1; c < cols; c++) if (matrix[r][c] < matrix[r][index]) index = c;
                r_min[r] = index;
            }
            for (int c = 0; c < cols; c++)
            {
                index = 0;
                for (int r = 1; r < rows; r++) if (matrix[r][c] > matrix[index][c]) index = r;
                c_max[c] = index;
            }

            List<int> result = new List<int>();
            for (int r = 0; r < rows; r++)       // 这个地方可以优化为小表驱动大表，这里不写了
                if (c_max[r_min[r]] == r) result.Add(matrix[r][r_min[r]]);

            return result;
        }

        /// <summary>
        /// 与LuckyNumbers()一样
        /// 取巧的地方在于，题目保证二维数组中没有重复值，所以找每一行的最小值与每一行的最大值，不需要记录索引再找交叉，直接记录值找重复就可以
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> LuckyNumbers2(int[][] matrix)
        {
            int rows = matrix.Length, cols = matrix[0].Length, num;
            HashSet<int> set = new HashSet<int>(rows);
            for (int r = 0; r < rows; r++)
            {
                num = matrix[r][0];
                for (int c = 1; c < cols; c++) num = Math.Min(num, matrix[r][c]);
                set.Add(num);
            }

            List<int> result = new List<int>();
            for (int c = 0; c < cols; c++)
            {
                num = matrix[0][c];
                for (int r = 1; r < rows; r++) num = Math.Max(num, matrix[r][c]);
                if (set.Contains(num)) result.Add(num);
            }

            return result;
        }
    }
}
