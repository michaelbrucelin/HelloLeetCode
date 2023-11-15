using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1342
{
    public class Solution1342_2 : Interface1342
    {
        /// <summary>
        /// 二进制 + 数学
        /// 二进制中的0需要1次操作，二进制中的1需要2次操作，二进制最高位的1需要1次操作
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int NumberOfSteps(int num)
        {
            if (num == 0) return 0;

            int result = 0;
            while (num > 0)
            {
                result += (num & 1) + 1;
                num >>= 1;
            }

            return result - 1;
        }
    }
}
