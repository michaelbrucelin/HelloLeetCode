using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3307
{
    public class Solution3307 : Interface3307
    {
        /// <summary>
        /// 递推
        /// 找规律，逻辑同Solution3304_2, Solution3304_3
        /// 例如：
        /// k = 9， 只有第4次操作有效，9-1 的二进制是 1000
        /// k = 12，第1 2 4次操作有效，12-1的二进制是 1011
        /// </summary>
        /// <param name="k"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public char KthCharacter(long k, int[] operations)
        {
            if (--k == 0) return 'a';

            int offset = 0, ptr = 0;
            while (k > 0)
            {
                if ((k % 2) == 1) offset += operations[ptr];
                k >>= 1;
                ptr++;
            }
            offset %= 26;

            return (char)('a' + offset);
        }
    }
}
