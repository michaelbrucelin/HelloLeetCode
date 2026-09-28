using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1006
{
    public class Solution1006 : Interface1006
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Clumsy(int n)
        {
            if (n < 3) return n;
            if (n == 3) return 6;

            int result = n * (n - 1) / (n - 2);
            n -= 3;
            while (n > 0)
            {
                result += n--;
                if (n == 1) result -= 1;
                else if (n == 2) result -= 2;
                else if (n == 3) result -= 6;
                else result -= n * (n - 1) / (n - 2);  // n * (n - 1) / (n - 2) 在 n > 4 之后，恒等于 n+1
                n -= 3;
            }

            return result;
        }
    }
}
