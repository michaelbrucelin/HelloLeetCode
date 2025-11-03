using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0172
{
    public class Solution0172_2 : Interface0172
    {
        /// <summary>
        /// 遍历
        /// 逻辑同Solution0172，稍加改动，具体见代码
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TrailingZeroes(int n)
        {
            if (n == 0) return 0;

            int result = 0, k = 1;
            while ((k *= 5) <= n) result += n / k;

            return result;
        }
    }
}
