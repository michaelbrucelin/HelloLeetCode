using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0205
{
    public class Solution0205_2 : Interface0205
    {
        /// <summary>
        /// 与Solution0205逻辑一样，只不过将hashtable换为数组
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;

            int len = s.Length;
            char[] map = new char[128];
            bool[] set = new bool[128];
            for (int i = 0; i < len; i++)
            {
                int key = s[i], value = t[i];
                if (map[key] == 0)
                {
                    if (set[value]) return false;
                    map[key] = (char)value;
                    set[value] = true;
                }
                else
                {
                    if ((char)value != map[key]) return false;
                }
            }

            return true;
        }
    }
}
