using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1002
{
    public class Solution1002 : Interface1002
    {
        /// <summary>
        /// 自定义Hash
        /// 自定义hash的方法很多，但是这道题目没有给出数据的范围，所以直接使用按字符排序后的字符串作为hash值
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            string key; char[] chars;
            foreach (string str in strs)
            {
                chars = str.ToCharArray();
                Array.Sort(chars);
                key = new string(chars);
                if (map.TryGetValue(key, out var list)) list.Add(str); else map.Add(key, [str]);
            }

            IList<IList<string>> result = [];
            foreach (IList<string> list in map.Values) result.Add(list);
            return result;
        }

        /// <summary>
        /// 逻辑完全同GroupAnagrams()，由于题目限定字符串仅包含小写字母，所以可以使用计数排序
        /// 如果测试用例中的字符串长度都比较短，这样做就可能是负优化
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            string key;
            int[] cnts = new int[26];
            StringBuilder sb = new StringBuilder();
            foreach (string str in strs)
            {
                key = get_hash(str);
                if (map.TryGetValue(key, out var list)) list.Add(str); else map.Add(key, [str]);
            }

            IList<IList<string>> result = [];
            foreach (IList<string> list in map.Values) result.Add(list);
            return result;

            string get_hash(string s)
            {
                Array.Fill(cnts, 0);
                foreach (char c in s) cnts[c - 'a']++;
                sb.Clear();
                for (int i = 0; i < 26; i++) for (int j = 0; j < cnts[i]; j++) sb.Append((char)('a' + i));

                return sb.ToString();
            }
        }
    }
}
