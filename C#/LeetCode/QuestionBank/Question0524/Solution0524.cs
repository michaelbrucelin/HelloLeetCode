using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0524
{
    public class Solution0524 : Interface0524
    {
        /// <summary>
        /// 双指针
        /// 本质上就是在找子序列
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string FindLongestWord(string s, IList<string> dictionary)
        {
            string result = ""; int p1, p2, len1 = s.Length, len2;
            foreach (string word in dictionary)
            {
                if ((len2 = word.Length) > len1 || len2 < result.Length) continue;
                p1 = p2 = 0;
                while (p1 < len1 && p2 < len2)
                {
                    while (p1 < len1 && s[p1] != word[p2]) p1++;
                    if (p1 == len1) break;
                    p1++; p2++;
                }

                if (p2 == len2)
                {
                    // if (len2 > result.Length || (len2 == result.Length && string.CompareOrdinal(word, result) < 0)) result = word;
                    if (len2 > result.Length || string.CompareOrdinal(word, result) < 0) result = word;
                }
            }

            return result;
        }
    }
}
