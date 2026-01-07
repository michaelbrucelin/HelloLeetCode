using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3794
{
    public class Solution3794 : Interface3794
    {
        public string ReversePrefix(string s, int k)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0, j = k - 1; i < j; i++, j--) (chars[i], chars[j]) = (chars[j], chars[i]);

            return new string(chars);
        }
    }
}
