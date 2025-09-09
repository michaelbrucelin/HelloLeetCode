using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2327
{
    public class Solution2327_3 : Interface2327
    {
        /// <summary>
        /// 矩阵快速幂
        /// 逻辑同Solution2327，使用矩阵快速幂优化速度
        /// n = 6, delay = 2, forget = 4
        /// 1     0 1 1 0     0     0 1 1 0     1     0 1 1 0     1     0 1 1 0     1     0 1 1 0     2
        /// 0  \/ 1 0 0 0 --  1  \/ 1 0 0 0 --  0  \/ 1 0 0 0 --  1  \/ 1 0 0 0 --  1  \/ 1 0 0 0 --  1
        /// 0  /\ 0 1 0 0 --  0  /\ 0 1 0 0 --  1  /\ 0 1 0 0 --  0  /\ 0 1 0 0 --  1  /\ 0 1 0 0 --  1
        /// 0     0 0 1 0     0     0 0 1 0     0     0 0 1 0     1     0 0 1 0     0     0 0 1 0     1
        /// 矩阵如下，第一行第一个1为delay-1列，最后一个1为倒数第二列
        /// 0 1 1 0
        /// 1 0 0 0
        /// 0 1 0 0
        /// 0 0 1 0
        /// 
        /// 逻辑没问题，TLE了，具体问题具体分析，这道题本身数据量不大，但是矩阵计算导致每个单元的计算量陡增，具体参考测试用例03
        /// </summary>
        /// <param name="n"></param>
        /// <param name="delay"></param>
        /// <param name="forget"></param>
        /// <returns></returns>
        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            const int MOD = (int)1e9 + 7;
            long[,] unit = new long[forget, forget], matrix = new long[forget, forget];
            for (int i = delay - 1; i <= forget - 2; i++) unit[0, i] = 1;
            for (int i = 1; i < forget; i++) unit[i, i - 1] = 1;

            n--;
            if ((n & 1) == 1)
            {
                for (int i = delay - 1; i <= forget - 2; i++) matrix[0, i] = 1;
                for (int i = 1; i < forget; i++) matrix[i, i - 1] = 1;
            }
            else
            {
                for (int i = 0; i < forget; i++) matrix[i, i] = 1;
            }
            while ((n >>= 1) > 0)
            {
                unit = matrixpower(unit, unit);
                if ((n & 1) == 1) matrix = matrixpower(matrix, unit);
            }

            long result = matrix[0, 0];                  // 结果就是matrix的第一列
            for (int i = 1; i < forget; i++) result = (result + matrix[i, 0]) % MOD;
            return (int)result;

            long[,] matrixpower(long[,] m1, long[,] m2)  // 限定本题，只算forget*gorget
            {
                long[,] result = new long[forget, forget];
                for (int r = 0; r < forget; r++) for (int c = 0; c < forget; c++)
                    {
                        for (int i = 0; i < forget; i++) result[r, c] = (result[r, c] + m1[r, i] * m2[i, c]) % MOD;
                    }

                return result;
            }
        }
    }
}
