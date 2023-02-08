using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0392
{
    public class Solution0392 : Interface0392
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence(string s, string t)
        {
            int ptr_s = 0, ptr_t = 0, len_s = s.Length, len_t = t.Length;
            while (ptr_s < len_s && ptr_t < len_t)
            {
                while (ptr_t < len_t && t[ptr_t] != s[ptr_s]) ptr_t++;
                if (ptr_t < len_t) { ptr_s++; ptr_t++; }
            }

            return ptr_s == len_s;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence2(string s, string t)
        {
            if (s.Length == 0) return true;

            int id = t.IndexOf(s[0]);
            if (id == -1) return false;
            return IsSubsequence2(s.Substring(1), t.Substring(id + 1));
        }
    }
}
