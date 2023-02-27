using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0844
{
    public class Solution0844 : Interface0844
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool BackspaceCompare(string s, string t)
        {
            StringBuilder sb_s = new StringBuilder();
            for (int i = s.Length - 1, skip = 0; i >= 0; i--)
            {
                if (s[i] == '#') skip++; else if (skip > 0) skip--; else sb_s.Insert(0, s[i]);
            }
            StringBuilder sb_t = new StringBuilder();
            for (int i = t.Length - 1, skip = 0; i >= 0; i--)
            {
                if (t[i] == '#') skip++; else if (skip > 0) skip--; else sb_t.Insert(0, t[i]);
            }

            if (sb_s.Length != sb_t.Length) return false;
            return sb_s.ToString() == sb_t.ToString();
        }

        /// <summary>
        /// 与BackspaceCompare()一样，使用编码手段精简代码
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool BackspaceCompare2(string s, string t)
        {
            StringBuilder sb_s = new StringBuilder(), sb_t = new StringBuilder();

            StringBuilder sb = sb_s; string str = s; bool repeat = true;
            Repeat:
            for (int i = str.Length - 1, skip = 0; i >= 0; i--)
            {
                if (str[i] == '#') skip++; else if (skip > 0) skip--; else sb.Insert(0, str[i]);
            }
            if (repeat)
            {
                sb = sb_t; str = t; repeat = false;
                goto Repeat;
            }

            if (sb_s.Length != sb_t.Length) return false;
            return sb_s.ToString() == sb_t.ToString();
        }
    }
}
