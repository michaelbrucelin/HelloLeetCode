using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2062
{
    public class Solution2062 : Interface2062
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int CountVowelSubstrings(string word)
        {
            Dictionary<char, int> map = new Dictionary<char, int>() { { 'a', 0 }, { 'e', 1 }, { 'i', 2 }, { 'o', 3 }, { 'u', 4 } };
            int[] buffer = new int[5];
            int result = 0, len = word.Length;
            for (int i = 0; i < len - 4; i++) for (int j = i + 4; j < len; j++)
                {
                    Array.Fill(buffer, 0);
                    for (int k = i; k <= j; k++)
                    {
                        if (!map.ContainsKey(word[k])) goto Next;
                        buffer[map[word[k]]]++;
                    }
                    if (buffer.All(cnt => cnt > 0)) result++;
                    Next:;
                }

            return result;
        }

        /// <summary>
        /// 暴力解
        /// 错的，稍后改一下
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int CountVowelSubstrings2(string word)
        {
            HashSet<char> set = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };
            HashSet<char> buffer = new HashSet<char>();

            int result = 0, len = word.Length;
            for (int i = 0; i < len - 4; i++)
            {
                buffer.Clear();
                for (int j = i; j < len; j++)
                {
                    if (!set.Contains(word[j])) break;
                    buffer.Add(word[j]);
                    if (buffer.Count == 5) result++;
                }
            }

            return result;
        }
    }
}
