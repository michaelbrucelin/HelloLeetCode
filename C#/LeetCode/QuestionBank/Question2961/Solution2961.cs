using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2961
{
    public class Solution2961 : Interface2961
    {
        private static readonly int[][] mod10 = [[0], [1], [2, 4, 8, 6], [3, 9, 7, 1], [4, 6], [5], [6], [7, 9, 3, 1], [8, 4, 2, 6], [9, 1]];

        /// <summary>
        /// 快速幂
        /// 1. 对10取模，有循环节
        /// 2. 对m取模，用快速幂
        /// </summary>
        /// <param name="variables"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<int> GetGoodIndices(int[][] variables, int target)
        {
            List<int> result = new List<int>();
            int a, b, ab10, c, m, len = variables.Length;
            for (int i = 0; i < len; i++)
            {
                (a, b, c, m) = (variables[i][0] % 10, variables[i][1], variables[i][2], variables[i][3]);
                ab10 = mod10[a][(b - 1) % mod10[a].Length];
                if (m == 10)
                {
                    if (mod10[ab10][(c - 1) % mod10[ab10].Length] == target) result.Add(i);
                }
                else
                {
                    if (FastPowMod(ab10, c, m) == target) result.Add(i);
                }
            }

            return result;
        }

        private int FastPowMod(int x, int y, int z)
        {
            int result = 1, mod = x % z;
            if ((y & 1) == 1) result = mod;
            while ((y >>= 1) > 0)
            {
                mod = mod * mod % z;
                if ((y & 1) == 1) result = result * mod % z;
            }

            return result;
        }
    }
}
