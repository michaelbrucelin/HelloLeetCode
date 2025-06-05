using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1061
{
    public class Solution1061 : Interface1061
    {
        /// <summary>
        /// 并查集
        /// 用最小的元素作为根
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="baseStr"></param>
        /// <returns></returns>
        public string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            int len = s1.Length;
            char[] union = new char[26];
            for (int i = 0; i < 26; i++) union[i] = (char)('a' + i);
            for (int i = 0; i < len; i++) if (s1[i] != s2[i]) union_set(s1[i], s2[i]);

            char[] result = new char[len = baseStr.Length];
            for (int i = 0; i < len; i++) result[i] = find_set(baseStr[i]);

            return new string(result);

            void union_set(char x, char y)
            {
                char _x = find_set(x), _y = find_set(y);
                if (_x != _y)
                {
                    if (_x < _y) union[_y - 'a'] = _x; else union[_x - 'a'] = _y;
                }
            }

            char find_set(char x)
            {
                if (union[x - 'a'] != x) union[x - 'a'] = find_set(union[x - 'a']);
                return union[x - 'a'];
            }
        }
    }
}
