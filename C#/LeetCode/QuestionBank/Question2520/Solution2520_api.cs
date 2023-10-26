using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2520
{
    public class Solution2520_api : Interface2520
    {
        public int CountDigits(int num)
        {
            return num.ToString().Count(c => num % (c - '0') == 0);  // 题目限定num中不包含数字0
        }
    }
}
