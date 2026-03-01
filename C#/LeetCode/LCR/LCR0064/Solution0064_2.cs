using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0064
{
    public class Solution0064_2
    {
    }

    /// <summary>
    /// 暴力，把字符串保存到集合中，暴力查找每一种可能
    /// </summary>
    public class MagicDictionary_2 : Interface0064
    {
        public MagicDictionary_2()
        {
            set = new HashSet<string>();
        }

        private HashSet<string> set;

        public void BuildDict(string[] dictionary)
        {
            foreach (string s in dictionary) set.Add(s);
        }

        public bool Search(string searchWord)
        {
            char[] chars = searchWord.ToCharArray();
            int len = searchWord.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    chars[i] = (char)('a' + j);
                    if (chars[i]! != searchWord[i] && set.Contains(new string(chars))) return true;
                }
                chars[i] = searchWord[i];
            }

            return false;
        }
    }
}