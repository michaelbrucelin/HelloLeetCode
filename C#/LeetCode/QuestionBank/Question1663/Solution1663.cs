using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1663
{
    public class Solution1663 : Interface1663
    {
        /// <summary>
        /// 数学分析，鸡兔同笼
        /// 具体见Solution1663.md
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetSmallestString(int n, int k)
        {
            if (k == n) return new string('a', n);

            var info = Math.DivRem(k - n, 25);
            int right = info.Quotient, mid = info.Remainder;
            if (mid == 0)
            {
                if (right == n)
                    return new string('z', n);
                else
                    return $"{new string('a', n - right)}{new string('z', right)}";
            }
            else
            {
                return $"{new string('a', n - right - 1)}{(char)(mid + 97)}{new string('z', right)}";
            }
        }
    }
}
