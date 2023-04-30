using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2273
{
    public class Solution2273 : Interface2273
    {
        public IList<string> RemoveAnagrams(string[] words)
        {
            List<string> result = new List<string>();
            int p1 = 0, p2, len = words.Length;
            int[] freq;
            while (p1 < len)
            {
                while (p1 + 1 < len && words[p1 + 1].Length != words[p1].Length) result.Add(words[p1++]);
                if ((p2 = p1 + 1) < len)
                {
                    freq = CalFreq(words[p1]);
                    while (p2 < len && Enumerable.SequenceEqual(freq, CalFreq(words[p2]))) p2++;
                    result.Add(words[p1]);
                    p1 = p2;
                }
                else
                {
                    result.Add(words[p1]); break;
                }
            }

            return result;
        }

        private int[] CalFreq(string word)
        {
            int[] freq = new int[26];
            for (int i = 0; i < word.Length; i++) freq[word[i] - 'a']++;

            return freq;
        }

        /// <summary>
        /// 与RemoveAnagrams()一样，更换了判断异构词的标准
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<string> RemoveAnagrams2(string[] words)
        {
            List<string> result = new List<string>();
            int p1 = 0, p2, len = words.Length;
            while (p1 < len)
            {
                while (p1 + 1 < len && words[p1 + 1].Length != words[p1].Length) result.Add(words[p1++]);
                if ((p2 = p1 + 1) < len)
                {
                    var freq = words[p1].GroupBy(c => c).OrderBy(g => g.Key).Select(g => g.Count() * 100 + (g.Key - 'a'));
                    while (p2 < len && Enumerable.SequenceEqual(freq, words[p2].GroupBy(c => c).OrderBy(g => g.Key).Select(g => g.Count() * 100 + (g.Key - 'a')))) p2++;
                    result.Add(words[p1]);
                    p1 = p2;
                }
                else
                {
                    result.Add(words[p1]); break;
                }
            }

            return result;
        }

        /// <summary>
        /// 与RemoveAnagrams()一样，更换了判断异构词的标准
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<string> RemoveAnagrams3(string[] words)
        {
            List<string> result = new List<string>();
            int p1 = 0, p2, len = words.Length;
            while (p1 < len)
            {
                while (p1 + 1 < len && words[p1 + 1].Length != words[p1].Length) result.Add(words[p1++]);
                if ((p2 = p1 + 1) < len)
                {
                    var freq = words[p1].OrderBy(c => c);
                    while (p2 < len && Enumerable.SequenceEqual(freq, words[p2].OrderBy(c => c))) p2++;
                    result.Add(words[p1]);
                    p1 = p2;
                }
                else
                {
                    result.Add(words[p1]); break;
                }
            }

            return result;
        }
    }
}
