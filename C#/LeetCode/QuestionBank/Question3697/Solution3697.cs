using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3697
{
    public class Solution3697 : Interface3697
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] DecimalRepresentation(int n)
        {
            List<int> result = [];
            int _base = 1, digit;
            while (n > 0)
            {
                digit = n % 10;
                if (digit != 0) result.Add(digit * _base);
                _base *= 10;
                n /= 10;
            }

            result.Reverse();
            return [.. result];
        }
    }
}
