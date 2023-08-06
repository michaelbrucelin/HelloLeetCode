using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2169
{
    public class Solution2169 : Interface2169
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int CountOperations(int num1, int num2)
        {
            int result = 0;
            while (num1 > 0 && num2 > 0)
            {
                result++;
                if (num1 >= num2) num1 -= num2; else num2 -= num1;
            }

            return result;
        }

        /// <summary>
        /// “倍速”模拟
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int CountOperations2(int num1, int num2)
        {
            int result = 0;
            while (num1 > 0 && num2 > 0)
            {
                if (num1 >= num2)
                {
                    result += num1 / num2; num1 %= num2;
                }
                else
                {
                    result += num2 / num1; num2 %= num1;
                }
            }

            return result;
        }
    }
}
