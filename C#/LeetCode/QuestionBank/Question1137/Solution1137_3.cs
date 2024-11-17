using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1137
{
    public class Solution1137_3 : Interface1137
    {
        /// <summary>
        /// 矩阵快速幂
        /// 题目限定的n的范围，没必要使用矩阵快速幂来加速，甚至会使程序更慢，这里只是写着玩的
        /// Tn3   1 1 1   Tn2
        /// Tn2 = 1 0 0 * Tn1
        /// Tn1   0 1 0   Tn
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci(int n)
        {
            int[] init = [0, 1, 1];
            if (n < 3) return init[n];

            int[,] unit = { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 } };
            int[,] k;
            int power = n - 2;
            k = (power & 1) == 1 ? new int[3, 3] { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 } } : new int[3, 3] { { 1, 0, 0 }, { 1, 0, 0 }, { 0, 0, 1 } };
            power >>= 1;
            while (power != 0)
            {
                unit = matrixpower(unit, unit);
                if ((power & 1) == 1) k = matrixpower(k, unit);
                power >>= 1;
            }

            return k[0, 0] * init[2] + k[0, 1] * init[1] + k[0, 2] * init[0];

            int[,] matrixpower(int[,] m1, int[,] m2)
            {
                int[,] result = new int[3, 3];
                for (int r = 0; r < 3; r++) for (int c = 0; c < 3; c++)
                    {
                        for (int i = 0; i < 3; i++) result[r, c] += m1[r, i] * m2[i, c];
                    }
                return result;
            }
        }
    }
}
