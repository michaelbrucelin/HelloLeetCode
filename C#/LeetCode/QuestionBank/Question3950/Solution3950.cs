using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3950
{
    public class Solution3950 : Interface3950
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool ConsecutiveSetBits(int n)
        {
            int cnt = 0, prev = 0, curr;
            while (n > 0)
            {
                curr = n & 1;
                cnt += prev & curr;
                prev = curr;
                n >>= 1;
            }

            return cnt == 1;
        }
    }
}
