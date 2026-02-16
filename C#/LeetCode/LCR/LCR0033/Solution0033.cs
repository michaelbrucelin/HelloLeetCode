using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0033
{
    public class Solution0033 : Interface0033
    {
        /// <summary>
        /// 哈希
        /// 使用排序后的字符串做hash
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            string key; char[] _str;
            foreach (string str in strs)
            {
                _str = str.ToArray();
                Array.Sort(_str);
                key = new string(_str);
                if (map.TryGetValue(key, out var list)) list.Add(str); else map.Add(key, [str]);
            }

            return [.. map.Values];
        }
    }
}
