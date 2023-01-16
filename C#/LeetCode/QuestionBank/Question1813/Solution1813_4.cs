using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1813
{
    public class Solution1813_4 : Interface1813
    {
        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            string[] words1 = sentence1.Split(' ');
            string[] words2 = sentence2.Split(' ');

            int len1 = words1.Length, len2 = words2.Length;
            int i = 0, j = 0;
            while (i < len1 && i < len2 && words1[i] == words2[i]) i++;
            while (len1 - j - 1 >= i && len2 - j - 1 >= i && words1[len1 - j - 1] == words2[len2 - j - 1]) j++;

            return i + j == Math.Min(len1, len2);
        }
    }
}
