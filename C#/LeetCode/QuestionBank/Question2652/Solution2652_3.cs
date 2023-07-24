using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2652
{
    public class Solution2652_3 : Interface2652
    {
        /// <summary>
        /// 容斥原理
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfMultiples(int n)
        {
            int result = 0, cnt;
            cnt = n / 3; result += (((cnt + 1) * cnt) >> 1) * 3;
            cnt = n / 5; result += (((cnt + 1) * cnt) >> 1) * 5;
            cnt = n / 7; result += (((cnt + 1) * cnt) >> 1) * 7;
            cnt = n / 15; result -= (((cnt + 1) * cnt) >> 1) * 15;
            cnt = n / 21; result -= (((cnt + 1) * cnt) >> 1) * 21;
            cnt = n / 35; result -= (((cnt + 1) * cnt) >> 1) * 35;
            cnt = n / 105; result += (((cnt + 1) * cnt) >> 1) * 105;

            return result;
        }
    }
}
