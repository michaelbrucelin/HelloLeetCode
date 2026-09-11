using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2165
{
    public class Solution2165 : Interface2165
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public long SmallestNumber(long num)
        {
            if (num == 0) return 0;

            long result = 0;
            int[] digits = new int[10];

            if (num > 0)
            {
                while (num > 0) { digits[num % 10]++; num /= 10; }
                int p = 0;
                while (digits[++p] == 0) ;
                result = p;
                digits[p]--;
                for (int j = digits[0]; j > 0; j--) result *= 10;
                for (int i = p; i < 10; i++) for (int j = digits[i]; j > 0; j--) result = result * 10 + i;
            }
            else
            {
                num = -num;
                while (num > 0) { digits[num % 10]++; num /= 10; }
                for (int i = 9; i >= 0; i--) for (int j = digits[i]; j > 0; j--) result = result * 10 + i;
                result = -result;
            }

            return result;
        }
    }
}
