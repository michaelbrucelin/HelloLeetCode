using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3856
{
    public class Solution3856 : Interface3856
    {
        private static readonly HashSet<char> vowel = ['a', 'e', 'i', 'o', 'u'];

        /// <summary>
        /// 倒序遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string TrimTrailingVowels(string s)
        {
            int ptr = s.Length;
            while (--ptr >= 0 && vowel.Contains(s[ptr])) ;

            return s[0..(ptr + 1)];
        }
    }
}
