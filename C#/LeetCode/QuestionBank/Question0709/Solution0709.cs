using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0709
{
    public class Solution0709 : Interface0709
    {
        public string ToLowerCase(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsUpper(chars[i])) chars[i] = (char)(chars[i] | 32);
            }

            return new string(chars);
        }
    }
}
