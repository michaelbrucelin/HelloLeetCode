using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3340
{
    public class Solution3340 : Interface3340
    {
        public bool IsBalanced(string num)
        {
            int odd = 0, even = 0, len = num.Length;
            for (int i = 0; i < len; i += 2) odd += num[i] - '0';
            for (int i = 1; i < len; i += 2) even += num[i] - '0';

            return odd == even;
        }

        public bool IsBalanced2(string num)
        {
            int odd = 0, even = 0, len = num.Length;
            for (int i = 0; i < len; i++)
            {
                odd += (i & 1) * (num[i] - '0');
                even += ((i & 1) ^ 1) * (num[i] - '0');
            }

            return odd == even;
        }
    }
}
