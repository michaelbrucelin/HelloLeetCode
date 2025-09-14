using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0966
{
    public class Solution0966 : Interface0966
    {
        /// <summary>
        /// 暴力查找
        /// 1. wordlist --> HashSet，O(1)的查找第1优先级，完全匹配
        /// 2. lower(wordlist) --> HashSet，O(1)的查找第2优先级，完全匹配
        /// 3. func(wordlist) --> HashSet，O(1)的查找第3优先级，元音匹配
        ///     func(s) 将 s 中的元音全部替换为a
        /// </summary>
        /// <param name="wordlist"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public string[] Spellchecker(string[] wordlist, string[] queries)
        {
            char[] map = ['a', 'b', 'c', 'd', 'a', 'f', 'g', 'h', 'a', 'j', 'k', 'l', 'm', 'n', 'a', 'p', 'q', 'r', 's', 't', 'a', 'v', 'w', 'x', 'y', 'z',
                          '[', '\\', ']', '^', '_', '`',
                          'a', 'b', 'c', 'd', 'a', 'f', 'g', 'h', 'a', 'j', 'k', 'l', 'm', 'n', 'a', 'p', 'q', 'r', 's', 't', 'a', 'v', 'w', 'x', 'y', 'z'];
            HashSet<string> set1 = [];
            Dictionary<string, string> set2 = [], set3 = [];
            string key;
            foreach (string word in wordlist)
            {
                set1.Add(word);
                key = word.ToLower();
                if (!set2.ContainsKey(key)) set2.Add(key, word);
                key = formatvowel(word);
                if (!set3.ContainsKey(key)) set3.Add(key, word);
            }

            int len = queries.Length;
            string[] result = new string[len];
            for (int i = 0; i < len; i++)
            {
                key = queries[i];
                if (set1.Contains(key)) { result[i] = key; continue; }
                key = queries[i].ToLower();
                if (set2.ContainsKey(key)) { result[i] = set2[key]; continue; }
                key = formatvowel(queries[i]);
                if (set3.ContainsKey(key)) { result[i] = set3[key]; continue; }
                result[i] = "";
            }
            return result;

            string formatvowel(string s)
            {
                char[] chars = [.. s];
                for (int i = 0; i < chars.Length; i++) chars[i] = map[chars[i] - 'A'];
                return new string(chars);
            }
        }
    }
}
