using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2180
{
    public class Solution2180 : Interface2180
    {
        /// <summary>
        /// 朴素的暴力解
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int CountEven(int num)
        {
            int result = 0;
            for (int i = 1; i <= num; i++)
            {
                int sum = 0, x = i;
                while (x > 0)
                {
                    var info = Math.DivRem(x, 10);
                    if ((info.Remainder & 1) != 0) sum++;
                    x = info.Quotient;
                }
                if ((sum & 1) != 1) result++;
            }

            return result;
        }

        /// <summary>
        /// 与上面的解完全一致，但是使用位运算进行了加速
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int CountEven2(int num)
        {
            int result = 0;
            for (int i = 1; i <= num; i++)
            {
                int sum = 0, x = i;
                while (x > 0)
                {
                    var info = Math.DivRem(x, 10);
                    sum ^= (info.Remainder & 1);    // if ((info.Remainder & 1) != 0) sum++;
                    x = info.Quotient;
                }
                result += (sum ^ 1);                // if ((sum & 1) != 1) result++;
            }

            return result;
        }
    }
}
