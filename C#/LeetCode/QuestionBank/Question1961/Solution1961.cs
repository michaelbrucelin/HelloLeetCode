using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1961
{
    public class Solution1961 : Interface1961
    {
        /// <summary>
        /// 逐字符比较
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public bool IsPrefixString(string s, string[] words)
        {
            int len = s.Length;
            string word;
            for (int i = 0, j = 0; i < words.Length; i++)
            {
                word = words[i];
                if (j + word.Length > len) return false;
                for (int k = 0; k < word.Length; k++, j++)
                    if (word[k] != s[j]) return false;
                if (j == len) return true;
            }

            return false;
        }
    }
}
