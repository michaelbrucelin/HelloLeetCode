using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2549
{
    public class Solution2549_2 : Interface2549
    {
        /// <summary>
        /// 数学
        /// 1. 由于天数的限制是10^9，远远用不到
        /// 2. 初始状态是n，那么第2天必然有n-1,
        ///                     第3天必然有n-2,
        ///                     ...
        ///                     第k天必然有n-k，k < n-1，且n-k可能在前面就已经在结果中了
        /// 3. 所以结果就是n-1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int DistinctIntegers(int n)
        {
            if (n == 1) return 1;
            return n - 1;
        }
    }
}
