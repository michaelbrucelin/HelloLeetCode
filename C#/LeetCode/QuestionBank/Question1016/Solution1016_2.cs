using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1016
{
    public class Solution1016_2 : Interface1016
    {
        /// <summary>
        /// 暴力枚举
        /// 与Solution1016一样，针对字符串查找做了优化
        /// 优化：
        /// 由于s是固定的，可以一次性生成好next数组，然后自己写KMP来优化时间复杂度
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool QueryString(string s, int n)
        {
            uint[] mask = new uint[(n >> 5) + 1]; const int _m = 31;
            int[] next = GetNext(s);
            string _str;
            for (int _n = n, __n = 0, i = 0, j = 0; _n > 0; _n--)
            {
                i = _n >> 5; j = _n & _m; j = j != 0 ? j - 1 : _m;
                if (((mask[i] >> j) & 1) == 1) continue;

                _str = Convert.ToString(_n, 2);
                if (CharIndex_KMP(s, _str, next) > -1)
                {
                    mask[i] |= 1u << j;
                    __n = _n >> 1; while (__n >= 1)
                    {
                        i = __n >> 5; j = __n & _m; j = j != 0 ? j - 1 : _m;
                        mask[i] |= 1u << j;
                        __n >>= 1;
                    }
                }
                else return false;
            }

            return true;
        }

        public int CharIndex_KMP(string s, string t, int[] next)
        {
            if (s.Length < t.Length) return -1;
            if (s.Length == t.Length) return s == t ? 0 : -1;

            int i = 0, j = 0, len_s = s.Length, len_t = t.Length;
            while (len_s - i >= len_t - j)
            {
                while (i < len_s && j < len_t && s[i] == t[j]) { i++; j++; };

                if (j == len_t) return i - len_t;
                j = next[j];
                if (j == -1) { i++; j++; }
            }

            return -1;
        }

        private int[] GetNext(string s)
        {
            if (s.Length == 0) return new int[0];
            if (s.Length == 1) return new int[1] { -1 };
            if (s.Length == 2) return new int[2] { -1, 0 };

            int[] next = new int[s.Length]; next[0] = -1; next[1] = 0;
            int i = 2, j = 0;
            while (i < s.Length)
            {
                while (j >= 0 && s[i - 1] != s[j]) j = next[j];
                if (j == -1)
                {
                    if (s[i] != s[0]) next[i] = 0; else next[i] = -1;
                }
                else
                {
                    if (s[i] != s[j]) next[i] = j + 1; else next[i] = next[j];
                }
                i++; j++;
            }

            return next;
        }
    }
}
