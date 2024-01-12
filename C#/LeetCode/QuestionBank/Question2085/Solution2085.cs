using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2085
{
    public class Solution2085 : Interface2085
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="words1"></param>
        /// <param name="words2"></param>
        /// <returns></returns>
        public int CountWords(string[] words1, string[] words2)
        {
            Dictionary<string, int> dic1 = new Dictionary<string, int>();
            Dictionary<string, int> dic2 = new Dictionary<string, int>();
            foreach (string word in words1)
                if (dic1.ContainsKey(word)) dic1[word]++; else dic1.Add(word, 1);
            foreach (string word in words2)
                if (dic2.ContainsKey(word)) dic2[word]++; else dic2.Add(word, 1);

            int result = 0;
            foreach (string word in dic1.Keys)
                if (dic1[word] == 1 && dic2.ContainsKey(word) && dic2[word] == 1) result++;

            return result;
        }

        /// <summary>
        /// 逻辑同CountWords()，尝试一下C#中字典的另一种用法
        /// </summary>
        /// <param name="words1"></param>
        /// <param name="words2"></param>
        /// <returns></returns>
        public int CountWords2(string[] words1, string[] words2)
        {
            Dictionary<string, int> dic1 = new Dictionary<string, int>();
            Dictionary<string, int> dic2 = new Dictionary<string, int>();
            foreach (string word in words1)
                dic1[word] = dic1.GetValueOrDefault(word, 0) + 1;
            foreach (string word in words2)
                dic2[word] = dic2.GetValueOrDefault(word, 0) + 1;

            int result = 0;
            foreach (string word in dic1.Keys)
                if (dic1[word] == 1 && dic2.GetValueOrDefault(word, 0) == 1) result++;

            return result;
        }
    }
}
