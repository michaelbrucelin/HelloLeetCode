using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2643
{
    public class Solution2643 : Interface2643
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[] RowAndMaximumOnes(int[][] mat)
        {
            int[] result = new int[2];
            int rcnt = mat.Length, ccnt = mat[0].Length;
            for (int r = 0, _cnt; r < rcnt; r++)
            {
                _cnt = 0;
                for (int c = 0; c < ccnt; c++)
                {
                    _cnt += mat[r][c];
                }
                if (_cnt > result[1])
                {
                    result[0] = r; result[1] = _cnt;
                }
            }

            return result;
        }
    }
}
