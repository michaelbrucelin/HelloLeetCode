using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0073
{
    public class Solution0073_2 : Interface0073
    {
        /// <summary>
        /// 与Solution0073逻辑是一样的，但是使用matrix的第一行与第一列做额外的空间，注意matrix[0][0]不能使用两次
        /// </summary>
        public void SetZeroes(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            bool firstRow = false, firstCol = false;
            HashSet<int> rows = new HashSet<int>(), cols = new HashSet<int>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        matrix[r][0] = 0; matrix[0][c] = 0;
                        if (r == 0) firstRow = true;
                        if (c == 0) firstCol = true;
                    }
                }

            for (int r = 1; r < rcnt; r++) if (matrix[r][0] == 0) for (int c = 1; c < ccnt; c++) matrix[r][c] = 0;
            for (int c = 1; c < ccnt; c++) if (matrix[0][c] == 0) for (int r = 1; r < rcnt; r++) matrix[r][c] = 0;
            if (firstRow) for (int c = 0; c < ccnt; c++) matrix[0][c] = 0;
            if (firstCol) for (int r = 0; r < rcnt; r++) matrix[r][0] = 0;
        }
    }
}
