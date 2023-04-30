using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1252
{
    public class Solution1252_4 : Interface1252
    {
        public int OddCells(int m, int n, int[][] indices)
        {
            int[] rows = new int[m], cols = new int[n];
            for (int i = 0; i < indices.Length; i++)
            {
                rows[indices[i][0]]++; cols[indices[i][1]]++;
            }

            int result = 0;
            for (int r = 0; r < m; r++) for (int c = 0; c < n; c++)
                {
                    result += (rows[r] + cols[c]) & 1;
                }

            return result;
        }
    }
}
