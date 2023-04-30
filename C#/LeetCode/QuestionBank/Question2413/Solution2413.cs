using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2413
{
    public class Solution2413 : Interface2413
    {
        public int SmallestEvenMultiple(int n)
        {
            return (n & 1) == 0 ? n : n << 1;
        }

        /// <summary>
        /// 取消代码中的if-else，据说cpu执行的更快
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SmallestEvenMultiple2(int n)
        {
            return n * ((n & 1) + 1);
        }

        public int SmallestEvenMultiple3(int n)
        {
            return n << (n & 1);
        }
    }
}
