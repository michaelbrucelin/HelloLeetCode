using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1813
{
    public class Solution1813_3 : Interface1813
    {
        /// <summary>
        /// 与Solution1813思路一致，这里更多的使用了API
        /// </summary>
        /// <param name="sentence1"></param>
        /// <param name="sentence2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            int len1 = sentence1.Length, len2 = sentence2.Length;
            if (len1 == len2) return sentence1 == sentence2;
            if (len1 < len2)  // 始终向sentence2中插入
            {
                string t = sentence1; sentence1 = sentence2; sentence2 = t;
                len1 = len1 ^ len2; len2 = len1 ^ len2; len1 = len1 ^ len2;
            }

            if (sentence1.StartsWith($"{sentence2} ") || sentence1.EndsWith($" {sentence2}")) return true;

            int ptr = -1;
            while (++ptr < len2)
            {
                if (sentence2[ptr] == ' ')
                {
                    if (sentence1.StartsWith(sentence2.Substring(0, ptr + 1)) && sentence1.EndsWith(sentence2.Substring(ptr))) return true;
                }
            }

            return false;
        }
    }
}
