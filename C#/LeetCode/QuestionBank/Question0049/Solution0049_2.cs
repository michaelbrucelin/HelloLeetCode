using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0049
{
    public class Solution0049_2 : Interface0049
    {
        /// <summary>
        /// 排序
        /// 本质上仍然是状态压缩，逻辑同Solution0049，只是生成的key就是字符串排序后的结果，可以使用基数排序
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
                key = SortStr(str);
                if (!map.ContainsKey(key)) map.Add(key, new List<string>());
                map[key].Add(str);
            }

            return map.Values.ToList();

            string SortStr(string s)
            {
                Array.Fill(freq, 0);
                foreach (char c in s) freq[c - 'a']++;
                sb.Clear();
                for (int i = 0; i < 26; i++) for (int j = 0; j < freq[i]; j++) sb.Append((char)('a' + i));
                return sb.ToString();
            }
        }
    }
}
