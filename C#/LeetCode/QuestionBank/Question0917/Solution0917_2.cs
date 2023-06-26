using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0917
{
    public class Solution0917_2 : Interface0917
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseOnlyLetters(string s)
        {
            int len = s.Length;
            char[] chars = new char[len];
            int j = 0;
            while (j < len && !char.IsLetter(s[j])) chars[j] = s[j++];
            for (int i = len - 1; i >= 0; i--)
            {
                if (char.IsLetter(s[i]))
                {
                    chars[j++] = s[i];
                    while (j < len && !char.IsLetter(s[j])) chars[j] = s[j++];
                    if (j == len) break;
                }
            }

            return new string(chars);
        }
    }
}
