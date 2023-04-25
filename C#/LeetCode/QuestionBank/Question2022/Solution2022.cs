using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2022
{
    public class Solution2022 : Interface2022
    {
        public int[][] Construct2DArray(int[] original, int m, int n)
        {
            int len = original.Length;
            if (len != m * n) return new int[0][];

            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0, start = n * i; j < n; j++)
                    result[i][j] = original[start + j];
            }

            return result;
        }
    }
}
