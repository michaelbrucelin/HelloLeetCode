using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0868
{
    public class Solution0868_2 : Interface0868
    {
        /// <summary>
        /// 位运算
        /// n&(n-1)可以移除最低位的1
        /// n&(-n) 可以获取最低位的1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int BinaryGap(int n)
        {
            if (n == 0) return 0;

            int result = 0, last = (int)Math.Log2(n & (-n)), curr;
            while ((n &= n - 1) > 0)
            {
                curr = (int)Math.Log2(n & (-n));
                result = Math.Max(result, curr - last);
                last = curr;
            }

            return result;
        }
    }
}
