using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0190
{
    public class Solution0190 : Interface0190
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ReverseBits(int n)
        {
            int result = 0, pos = 0;
            while (n > 0)
            {
                result <<= 1;
                result |= n & 1;
                n >>= 1;
                pos++;
            }
            result <<= 32 - pos;

            return result;
        }
    }
}
