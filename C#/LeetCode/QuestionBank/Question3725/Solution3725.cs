using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3725
{
    public class Solution3725 : Interface3725
    {
        /// <summary>
        /// DP
        /// 题目限定mat中元素最大值为150，假定最大值为N，那么到第N层，最大公约数为[1-N]的数量都已知，那么第N+1层，显然最大公约数为[1-N]的数量也容易计算
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int CountCoprime(int[][] mat)
        {
            const int MOD = (int)1e9 + 7;
            int rcnt = mat.Length, ccnt = mat[0].Length, max = mat[0][0];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) max = Math.Max(max, mat[r][c]);
            int[,] dp = new int[rcnt, max + 1];
            for (int c = 0; c < ccnt; c++) dp[0, mat[0][c]]++;
            for (int r = 1, gcd; r < rcnt; r++) for (int c = 0; c < ccnt; c++) for (int i = 1; i <= max; i++)
                    {
                        gcd = getgcd(mat[r][c], i);
                        dp[r, gcd] = (dp[r, gcd] + dp[r - 1, i]) % MOD;
                    }

            return dp[rcnt - 1, 1];

            static int getgcd(int x, int y)
            {
                if (x == y) return x;

                int move = 0;
                while (x != y) switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }

                return x << move;
            }
        }

        /// <summary>
        /// 逻辑完全同CountCoprime()，做了几点优化试一试
        /// 1. 统计出每一行中每个元素出现的频次，优化大量重复值的场景
        ///     单独统计没有意义，这里是在寻找最大值时顺便统计的，如果没有重复值，这里就是负优化
        /// 2. 预处理任意两个元素的gcd
        /// 3. 滚动数组
        /// 还可以根据rcnt与ccnt的大小，决定由上至下dp还是由左至右dp，这里就不写了
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int CountCoprime2(int[][] mat)
        {
            throw new NotImplementedException();
        }
    }
}
