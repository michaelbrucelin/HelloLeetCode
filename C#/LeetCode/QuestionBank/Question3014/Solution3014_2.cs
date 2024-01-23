using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3014
{
    public class Solution3014_2 : Interface3014
    {
        public int MinimumPushes(string word)
        {
            var info = Math.DivRem(word.Length, 8);
            return (info.Quotient + 1) * ((info.Quotient << 2) + info.Remainder);
        }

        public int MinimumPushes2(string word)
        {
            int len = word.Length;
            return ((len >> 3) + 1) * (((len >> 3) << 2) + (len & 7));
        }
    }
}
