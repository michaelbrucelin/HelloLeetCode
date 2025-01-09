using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3297
{
    public class Solution3297 : Interface3297
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public long ValidSubstringCount(string word1, string word2)
        {
            if (word1.Length < word2.Length) return 0;

            long result = 0;
            int[] cnt1 = new int[26], cnt2 = new int[26];
            int len1 = word1.Length, len2 = word2.Length;
            for (int i = 0; i < len2; i++)
            {
                cnt1[word1[i] - 'a']++; cnt2[word2[i] - 'a']++;
            }
            int p1 = 0, p2 = len2 - 1;
            while (p2 < len1)
            {
                while (!Check() && ++p2 < len1) cnt1[word1[p2] - 'a']++;
                if (p2 == len1) break;
                result += len1 - p2;
                cnt1[word1[p1++] - 'a']--;
            }

            return result;

            bool Check()
            {
                for (int i = 0; i < 26; i++) if (cnt1[i] < cnt2[i]) return false;
                return true;
            }
        }
    }
}
