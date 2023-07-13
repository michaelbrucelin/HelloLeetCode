using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0931
{
    public class Solution0931 : Interface0931
    {
        /// <summary>
        /// DFS
        /// 1. 遍历起点（第一行），O(n)，遍历下一行，O(3^n)，整体O(n3^n)，必然会超时，先写出来玩玩
        /// 提交超时，参考测试用例04
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MinFallingPathSum(int[][] matrix)
        {
            int result = 10001, len = matrix.Length;  // 按题意，10001是一个上界
            for (int i = 0; i < len; i++)
                result = Math.Min(result, dfs(matrix, len, 0, i, 0));

            return result;
        }

        private int dfs(int[][] matrix, int len, int r, int c, int sum)
        {
            if (r >= len) return sum;

            sum += matrix[r][c];
            int result = dfs(matrix, len, r + 1, c, sum);
            if (c - 1 >= 0) result = Math.Min(result, dfs(matrix, len, r + 1, c - 1, sum));
            if (c + 1 < len) result = Math.Min(result, dfs(matrix, len, r + 1, c + 1, sum));

            return result;
        }
    }
}
