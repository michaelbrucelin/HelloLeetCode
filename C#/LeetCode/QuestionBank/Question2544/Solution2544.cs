using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2544
{
    public class Solution2544 : Interface2544
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int AlternateDigitSum(int n)
        {
            int result = 0, flag = 1;
            while (n > 0)
            {
                result += n % 10 * flag;
                n /= 10;
                flag *= -1;
            }

            return result * flag * -1;
        }
    }
}
