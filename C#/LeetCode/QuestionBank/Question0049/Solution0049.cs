using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0049
{
    public class Solution0049 : Interface0049
    {
        /// <summary>
        /// 状态压缩
        /// 为每个字符串生成一个字符串的key，用来标识字符串中字母的频次
        /// 例如："aabccc" --> "2-1-3-0-0-..."
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            string key;
            int[] freq = new int[26];
            StringBuilder sb = new StringBuilder();
            foreach (string str in strs)
            {
                key = GenKey(str);
                if (!map.ContainsKey(key)) map.Add(key, new List<string>());
                map[key].Add(str);
            }

            return map.Values.ToList();

            string GenKey(string s)
            {
                Array.Fill(freq, 0);
                foreach (char c in s) freq[c - 'a']++;
                sb.Clear();
                foreach (int i in freq) sb.Append($"{i}-");
                return sb.ToString();
            }
        }
    }
}
