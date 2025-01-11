using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1582
{
    public class Solution1582_3 : Interface1582
    {
        /// <summary>
        /// 预处理
        /// 预处理除只有1个1的行与列，然后找二者的交集
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int NumSpecial(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            int[,] rcnts = new int[rcnt, 2], ccnts = new int[ccnt, 2];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (mat[r][c] != 0)
                    {
                        rcnts[r, 0]++; rcnts[r, 1] = c;
                        ccnts[c, 0]++; ccnts[c, 1] = r;
                    }
                }

            int result = 0;
            for (int r = 0; r < rcnt; r++)
            {
                if (rcnts[r, 0] == 1 && ccnts[rcnts[r, 1], 0] == 1) result++;
            }
            return result;
        }
    }
}
