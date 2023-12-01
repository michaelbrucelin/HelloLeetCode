using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2946
{
    public class Solution2946 : Interface2946
    {
        public bool AreSimilar(int[][] mat, int k)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            if ((k %= ccnt) == 0) return true;

            // 奇数行
            for (int r = 0; r < rcnt; r += 2) for (int c = 0; c < ccnt; c++)
                {
                    if (mat[r][c] != mat[r][(c + k) % ccnt]) return false;
                }
            // 偶数行
            for (int r = 1; r < rcnt; r += 2) for (int c = 0; c < ccnt; c++)
                {
                    if (mat[r][c] != mat[r][(c + k) % ccnt]) return false;
                }

            return true;
        }

        /// <summary>
        /// 与AreSimilar()逻辑一样，将取余改为减法，来加速
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool AreSimilar2(int[][] mat, int k)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            if ((k %= ccnt) == 0) return true;

            // 奇数行
            for (int r = 0, c; r < rcnt; r += 2)
            {
                for (c = 0; c < ccnt - k; c++) if (mat[r][c] != mat[r][c + k]) return false;
                for (; c < ccnt; c++) if (mat[r][c] != mat[r][c + k - ccnt]) return false;
            }
            // 偶数行
            for (int r = 1, c; r < rcnt; r += 2)
            {
                for (c = 0; c < ccnt - k; c++) if (mat[r][c] != mat[r][c + k]) return false;
                for (; c < ccnt; c++) if (mat[r][c] != mat[r][c + k - ccnt]) return false;
            }

            return true;
        }
    }
}
