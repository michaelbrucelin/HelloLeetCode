using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3226
{
    public class Solution3226_2 : Interface3226
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinChanges(int n, int k)
        {
            int xor = n ^ k;
            if ((k & xor) > 0) return -1;

            int result = 0, _n = n & xor;
            while (_n > 0)
            {
                result++; _n &= _n - 1;
            }

            return result;
        }
    }
}
