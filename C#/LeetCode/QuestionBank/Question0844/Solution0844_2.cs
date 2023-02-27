using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0844
{
    public class Solution0844_2 : Interface0844
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool BackspaceCompare(string s, string t)
        {
            int ptr_s = s.Length - 1, ptr_t = t.Length - 1, skip_s = 0, skip_t = 0;
            while (ptr_s >= 0 || ptr_t >= 0)
            {
                while (ptr_s >= 0 && (s[ptr_s] == '#' || skip_s > 0))
                {
                    if (s[ptr_s] == '#') skip_s++; else skip_s--;
                    ptr_s--;
                }
                while (ptr_t >= 0 && (t[ptr_t] == '#' || skip_t > 0))
                {
                    if (t[ptr_t] == '#') skip_t++; else skip_t--;
                    ptr_t--;
                }

                switch ((ptr_s, ptr_t))
                {
                    case ( >= 0, >= 0):
                        if (s[ptr_s--] != t[ptr_t--]) return false;
                        break;
                    case ( >= 0, < 0):
                    case ( < 0, >= 0):
                        return false;
                }
            }

            return true;
        }
    }
}
