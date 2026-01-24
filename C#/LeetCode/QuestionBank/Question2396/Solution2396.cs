using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2396
{
    public class Solution2396 : Interface2396
    {
        /// <summary>
        /// 暴力计算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsStrictlyPalindromic(int n)
        {
            int[] bits = new int[32];
            for (int b = 2, _n, offset; b < n - 1; b++)
            {
                _n = n; offset = -1;
                while (_n > 0) { bits[++offset] = _n % b; _n /= b; }
                for (int i = 0, j = offset; i < j; i++, j--) if (bits[i] != bits[j]) return false;
            }

            return true;
        }
    }
}
