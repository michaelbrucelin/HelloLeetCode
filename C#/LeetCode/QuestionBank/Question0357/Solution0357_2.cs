using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0357
{
    public class Solution0357_2 : Interface0357
    {
        /// <summary>
        /// 排列组合
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountNumbersWithUniqueDigits(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 10;

            int result = 10;
            for (int i = 2, _result; i <= n; i++)
            {
                _result = 9;
                for (int j = 1, k = 9; j < i; j++, k--) _result *= k;
                result += _result;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同CountNumbersWithUniqueDigits()，稍加优化
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountNumbersWithUniqueDigits2(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 10;

            int result = 10, _result = 9;
            for (int i = 9; n > 1; i--, n--)
            {
                _result *= i;
                result += _result;
            }

            return result;
        }
    }
}
