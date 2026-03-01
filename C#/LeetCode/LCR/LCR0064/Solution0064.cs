using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0064
{
    public class Solution0064
    {
    }

    /// <summary>
    /// 暴力，把所有可能保存到集合中
    /// </summary>
    public class MagicDictionary : Interface0064
    {
        public MagicDictionary()
        {
            set = new HashSet<string>();
        }

        private HashSet<string> set;

        public void BuildDict(string[] dictionary)
        {
            char[] chars;
            int len;
            foreach (string s in dictionary)
            {
                chars = s.ToCharArray();
                len = s.Length;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        chars[i] = (char)('a' + j);
                        if (chars[i] != s[i]) set.Add(new string(chars));
                    }
                    chars[i] = s[i];
                }
            }
        }

        public bool Search(string searchWord)
        {
            return set.Contains(searchWord);
        }
    }
}
