using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2520
{
    public class Solution2520 : Interface2520
    {
        public int CountDigits(int num)
        {
            int result = 0, _num = num;
            while (_num > 0)
            {
                if (num % (_num % 10) == 0) result++;  // 题目限定num中不包含数字0
                _num /= 10;
            }

            return result;
        }
    }
}
