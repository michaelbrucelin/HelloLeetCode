using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2264
{
    public class Solution2264_2 : Interface2264
    {
        /// <summary>
        /// KMP
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string LargestGoodInteger(string num)
        {
            int[] next = GetNext(num);
            if (KMP(num, "999", next) > -1) return "999";
            if (KMP(num, "888", next) > -1) return "888";
            if (KMP(num, "777", next) > -1) return "777";
            if (KMP(num, "666", next) > -1) return "666";
            if (KMP(num, "555", next) > -1) return "555";
            if (KMP(num, "444", next) > -1) return "444";
            if (KMP(num, "333", next) > -1) return "333";
            if (KMP(num, "222", next) > -1) return "222";
            if (KMP(num, "111", next) > -1) return "111";
            if (KMP(num, "000", next) > -1) return "000";

            return "";
        }

        private int KMP(string s, string t, int[] next)
        {
            if (s.Length < t.Length) return -1;
            if (s.Length == t.Length) return s == t ? 0 : -1;

            int i = 0, j = 0, len_s = s.Length, len_t = t.Length;  // i是s的索引，j是t的索引
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
