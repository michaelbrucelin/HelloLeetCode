using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1941
{
    public class Solution1941 : Interface1941
    {
        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool AreOccurrencesEqual(string s)
        {
            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++) freq[s[i] - 'a']++;
            int first = 0; while (freq[first] == 0) first++;
            for (int i = first + 1; i < 26; i++)
                if (freq[i] != 0 && freq[i] != freq[first]) return false;

            return true;
        }
    }
}
