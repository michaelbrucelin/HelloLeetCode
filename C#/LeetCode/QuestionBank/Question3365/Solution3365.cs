using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3365
{
    public class Solution3365 : Interface3365
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool IsPossibleToRearrange(string s, string t, int k)
        {
            if (s.Length != t.Length || s.Length % k != 0) return false;
            if (s.Length == k) return true;

            int len = s.Length; k = len / k;
            string key;
            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = k; i <= len; i += k)
            {
                key = s[(i - k)..i];
                if (map.TryGetValue(key, out int cnt)) map[key] = ++cnt; else map.Add(key, 1);
            }
            for (int i = k; i <= len; i += k)
            {
                key = t[(i - k)..i];
                if (map.TryGetValue(key, out int cnt))
                {
                    if (cnt > 1) map[key] = --cnt; else map.Remove(key);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
