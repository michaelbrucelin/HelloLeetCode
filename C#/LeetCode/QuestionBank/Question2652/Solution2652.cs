using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2652
{
    public class Solution2652 : Interface2652
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfMultiples(int n)
        {
            int result = 0;
            for (int i = 1; i <= n; i++)
                if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0) result += i;

            return result;
        }
    }
}
