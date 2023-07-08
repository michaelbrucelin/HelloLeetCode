using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0073
{
    public class Solution0073 : Interface0073
    {
        /// <summary>
        /// 使用两个数组，分别记录需要置0的行与列
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeroes(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            HashSet<int> rows = new HashSet<int>(), cols = new HashSet<int>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (matrix[r][c] == 0) { rows.Add(r); cols.Add(c); }
                }

            foreach (int r in rows) for (int c = 0; c < ccnt; c++) matrix[r][c] = 0;
            foreach (int c in cols) for (int r = 0; r < rcnt; r++) matrix[r][c] = 0;
        }
    }
}
