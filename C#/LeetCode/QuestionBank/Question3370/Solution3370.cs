using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3370
{
    public class Solution3370 : Interface3370
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SmallestNumber(int n)
        {
            int result = 0;
            while (n > 0)
            {
                result <<= 1;
                result |= 1;
                n >>= 1;
            }

            return result;
        }
    }
}
