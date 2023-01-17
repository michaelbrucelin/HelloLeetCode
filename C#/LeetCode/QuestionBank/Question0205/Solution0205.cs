using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0205
{
    public class Solution0205 : Interface0205
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;

            int len = s.Length;
            Dictionary<char, char> map = new Dictionary<char, char>();
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < len; i++)
            {
                char key = s[i], value = t[i];
                if (!map.ContainsKey(key))
                {
                    if (set.Contains(value)) return false;
                    map.Add(key, value);
                    set.Add(value);
                }
                else
                {
                    if (value != map[key]) return false;
                }
            }

            return true;
        }
    }
}
