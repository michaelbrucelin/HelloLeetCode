using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3577
{
    public class Solution3577 : Interface3577
    {
        /// <summary>
        /// 脑筋急转弯，排列组合
        /// 1. 开锁具有传递性，即a可以打开b，b可以打开c，则a可以打开c
        ///     - 如果有一把锁无法被编号为0的锁打开，则无解
        ///     - 如果有解，解为(n-1)!
        /// </summary>
        /// <param name="complexity"></param>
        /// <returns></returns>
        public int CountPermutations(int[] complexity)
        {
            long result = 1; int len = complexity.Length;
            const int MOD = (int)1e9 + 7;
            for (int i = 1; i < len; i++)
            {
                if (complexity[i] <= complexity[0]) return 0;
                result = result * i % MOD;
            }

            return (int)result;
        }
    }
}
