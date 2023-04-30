using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0290
{
    public class Solution0290 : Interface0290
    {
        /// <summary>
        /// 类似于C的朴素解
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool WordPattern(string pattern, string s)
        {
            int len = pattern.Length, cnt = 0;
            for (int i = 0; i < s.Length; i++) if (s[i] == ' ') cnt++;
            if (len != cnt + 1) return false;

            string[] map = new string[26];
            HashSet<string> set = new HashSet<string>();
            int ptr = 0, left, right = 0; len = s.Length;
            while ((left = right) < len)
            {
                while (right + 1 < len && s[right + 1] != ' ') right++;
                string str = s.Substring(left, right - left + 1);
                int id = pattern[ptr++] - 'a';
                if (map[id] == null)
                {
                    if (set.Contains(str)) return false; else { map[id] = str; set.Add(str); }
                }
                else if (map[id] != str) return false;

                right += 2;  // 题目保证s中每个单词被单个空格分隔
            }

            return true;
        }

        /// <summary>
        /// 使用API
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool WordPattern2(string pattern, string s)
        {
            if (s.Count(c => c == ' ') + 1 != pattern.Length) return false;

            string[] map = new string[26];
            HashSet<string> set = new HashSet<string>();
            string[] strs = s.Split(' ');
            int ptr = 0;
            foreach (string str in strs)
            {
                int id = pattern[ptr++] - 'a';
                if (map[id] == null)
                {
                    if (set.Contains(str)) return false; else { map[id] = str; set.Add(str); }
                }
                else if (map[id] != str) return false;
            }

            return true;
        }
    }
}
