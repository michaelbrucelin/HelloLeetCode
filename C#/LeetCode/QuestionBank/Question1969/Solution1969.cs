using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1969
{
    public class Solution1969 : Interface1969
    {
        /// <summary>
        /// 数学构造
        /// 1. [1, 2^p-1] 中所有数字放一起统计，各个二进制位上 1 与 0 的数量是固定的，每一位上都有 2^(p-1) 个 1
        /// 2. 无论怎么交换，所有数字的和是不变的
        ///     所以就相当于构造 2^p-1 个正整数，每个位上有 2^(p-1) 个 1，并使其乘积最小即可
        /// 3. 如果两个正整数的和固定，这两个正整数越接近，乘积越大，越离散，乘积越小
        ///     所以，只要分为 2^(p-1)-1 个 1, 2^(p-1)-1 个 2^p-2, 1 个 2^p-1 乘积就是最小的，具体证明见Solution1969.md
        ///     2^(p-1)-1 个 2^p-2 可以使用快速幂计算
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int MinNonZeroProduct(int p)
        {
            const int MOD = (int)1e9 + 7;
            long _p = (1L << p) - 1;
            long result = _p % MOD, _result = --_p % MOD;
            for (int i = 1; i < p; i++)
            {
                result = result * _result % MOD;
                _result = _result * _result % MOD;
            }

            return (int)result;
        }
    }
}
