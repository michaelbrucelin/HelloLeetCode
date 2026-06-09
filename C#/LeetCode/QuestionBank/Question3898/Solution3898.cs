using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3898
{
    public class Solution3898 : Interface3898
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] FindDegrees(int[][] matrix)
        {
            int n = matrix.Length;
            int[] result = new int[n];
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) result[i] += matrix[i][j];

            return result;
        }
    }
}
