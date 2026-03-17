using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1727
{
    public class Solution1727_err : Interface1727
    {
        /// <summary>
        /// 遍历
        /// ...... 错的离谱了，脑子都想啥了
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int LargestSubmatrix(int[][] matrix)
        {
            int result = 0, rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[] cnts = new int[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) cnts[c] += matrix[r][c];
            Array.Sort(cnts);
            if (cnts[ccnt - 1] == 0) return 0;
            for (int c = 0; c < ccnt; c++) result = Math.Max(result, cnts[c] * (ccnt - c));

            return result;
        }
    }
}
