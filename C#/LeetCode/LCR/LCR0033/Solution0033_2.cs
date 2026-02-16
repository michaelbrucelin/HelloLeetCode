using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0033
{
    public class Solution0033_2 : Interface0033
    {
        /// <summary>
        /// 哈希
        /// 由于题目限定字符串只包含小写字母，所以这里使用词频作为哈希值
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            string key; int[] freq = new int[26]; StringBuilder sb = new StringBuilder();
            foreach (string str in strs)
            {
                Array.Fill(freq, 0);
                foreach (char c in str) freq[c - 'a']++;
                sb.Clear();
                for (int i = 0; i < 26; i++)
                {
                    sb.Append(freq[i]); sb.Append('-');
                }
                key = sb.ToString();
                if (map.TryGetValue(key, out var list)) list.Add(str); else map.Add(key, [str]);
            }

            return [.. map.Values];
        }
    }
}
