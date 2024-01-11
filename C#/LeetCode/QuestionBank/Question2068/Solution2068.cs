using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2068
{
    public class Solution2068 : Interface2068
    {
        /// <summary>
        /// 遍历，计数
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public bool CheckAlmostEquivalent(string word1, string word2)
        {
            int[] freq = new int[26];
            for (int i = 0; i < word1.Length; i++)
            {
                freq[word1[i] - 'a']++; freq[word2[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
                if (freq[i] > 3 || freq[i] < -3) return false;

            return true;
        }
    }
}
