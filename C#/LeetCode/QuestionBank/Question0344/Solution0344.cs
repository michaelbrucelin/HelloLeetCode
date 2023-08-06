using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0344
{
    public class Solution0344 : Interface0344
    {
        public void ReverseString(char[] s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right) Swap(s, left++, right--);
        }

        private void Swap(char[] s, int i, int j)
        {
            char t = s[i]; s[i] = s[j]; s[j] = t;
        }

        private void Swap2(char[] s, int i, int j)
        {
            s[i] = (char)(s[i] ^ s[j]);
            s[j] = (char)(s[i] ^ s[j]);
            s[i] = (char)(s[i] ^ s[j]);
        }
    }
}
