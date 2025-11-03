using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0172
{
    public class Solution0172 : Interface0172
    {
        /// <summary>
        /// 遍历
        /// 1个5增加一个0，偶数的数量远大于5的数量
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TrailingZeroes(int n)
        {
            if (n == 0) return 0;

            int result = 0;
            for (int i = 5, _n; i <= n; i += 5)
            {
                _n = i;
                while (_n % 5 == 0) { result++; _n /= 5; }
            }

            return result;
        }
    }
}
