using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3304
{
    public class Solution3304_2 : Interface3304
    {
        /// <summary>
        /// 本质上就是k-1二进制中1个数量
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public char KthCharacter(int k)
        {
            int cnt = 0;
            k--;
            while (k > 0)
            {
                cnt++; k &= k - 1;
            }

            return (char)(cnt + 'a');
        }
    }
}
