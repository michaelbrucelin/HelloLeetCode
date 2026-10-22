using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3945
{
    public class Solution3945 : Interface3945
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int DigitFrequencyScore(int n)
        {
            int result = 0;
            while (n > 0) { result += n % 10; n /= 10; }

            return result;
        }
    }
}
