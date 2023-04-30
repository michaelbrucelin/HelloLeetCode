using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0405
{
    public class Solution0405 : Interface0405
    {
        private static readonly char[] map = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        /// <summary>
        /// 唯一的难点在于处理负数，需要好好理解“补码”
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ToHex(int num)
        {
            StringBuilder result = new StringBuilder();

            long n = num;
            if (n < 0) n = -(((~-n) | (1 << 31)) + 1);
            while (n > 0)
            {
                var info = Math.DivRem(n, 16);
                result.Insert(0, map[info.Remainder]);
                n = info.Quotient;
            }

            return result.ToString();
        }

        /// <summary>
        /// 与ToHex()一样，使用位运算替代 /16 与 %16
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ToHex2(int num)
        {
            StringBuilder result = new StringBuilder();

            while (num > 0)
            {
                result.Insert(0, map[num & 15]);  // num % 16
                num >>= 4;                        // num /= 16
            }

            return result.ToString();
        }
    }
}
