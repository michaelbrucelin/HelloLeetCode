using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2108
{
    public class Solution2108 : Interface2108
    {
        public string FirstPalindrome(string[] words)
        {
            string result = string.Empty;
            for (int i = 0, left = 0, right = 0; i < words.Length; i++)
            {
                left = -1; right = words[i].Length;
                while (++left < --right && words[i][left] == words[i][right]) ;
                if (left >= right) return words[i];
            }

            return result;
        }
    }
}
