using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3099
{
    public class Solution3099 : Interface3099
    {
        public int SumOfTheDigitsOfHarshadNumber(int x)
        {
            int sum = 0, _x = x;
            while (_x > 0)
            {
                sum += _x % 10; _x /= 10;
            }

            return x % sum == 0 ? sum : -1;
        }
    }
}
