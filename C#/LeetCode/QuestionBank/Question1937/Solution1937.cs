using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1937
{
    public class Solution1937 : Interface1937
    {
        /// <summary>
        /// DP
        /// 如果矩阵只有两行，每行10^5/2个元素，就TLE了，先写出来试一下再说
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public long MaxPoints(int[][] points)
        {
            int rcnt = points.Length, ccnt = points[0].Length;
            long[,] dp = new long[rcnt, ccnt];
            for (int c = 0; c < ccnt; c++) dp[0, c] = points[0][c];
            for (int r = 1; r < rcnt; r++) for (int c = 0; c < ccnt; c++) for (int _c = 0; _c < ccnt; _c++)
                    {
                        dp[r, c] = Math.Max(dp[r, c], dp[r - 1, _c] - Math.Abs(c - _c) + points[r][c]);
                    }

            long result = 0;
            for (int c = 0; c < ccnt; c++) result = Math.Max(result, dp[rcnt - 1, c]);
            return result;
        }
    }
}
