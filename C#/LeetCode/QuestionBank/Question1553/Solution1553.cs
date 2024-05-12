using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1553
{
    public class Solution1553 : Interface1553
    {
        /// <summary>
        /// 递归
        /// 必然TLE，先写出来，然后再改为记忆化搜索
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinDays(int n)
        {
            if (n < 3) return n;

            int result = MinDays(n - 1);
            if ((n & 1) == 0) result = Math.Min(result, MinDays(n >> 1));
            if ((n % 3) == 0) result = Math.Min(result, MinDays(n / 3));

            return result + 1;
        }
    }
}
