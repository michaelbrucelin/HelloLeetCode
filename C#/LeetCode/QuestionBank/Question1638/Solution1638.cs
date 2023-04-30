using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1638
{
    public class Solution1638 : Interface1638
    {
        /// <summary>
        /// 暴力解
        /// 题目真心不容易读懂
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int CountSubstrings(string s, string t)
        {
            int result = 0, len1 = s.Length, len2 = t.Length; int len0 = Math.Min(len1, len2);
            for (int len = 1; len <= len0; len++)
            {
                for (int i = 0; i <= len1 - len; i++) for (int j = 0; j <= len2 - len; j++)
                    {
                        if (IsOneCharDiff(s, i, t, j, len)) result++;
                    }
            }

            return result;
        }

        /// <summary>
        /// 验证两个字串是否有且只有一个字符不同
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="i1"></param>
        /// <param name="s2"></param>
        /// <param name="i2"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private bool IsOneCharDiff(string s1, int i1, string s2, int i2, int len)
        {
            char c1 = '\0';
            for (int i = 0; i < len; i++)
            {
                if (s1[i1 + i] != s2[i2 + i])
                {
                    if (c1 == '\0')
                        c1 = s1[i1 + i];
                    else
                        return false;
                }
            }

            return c1 != '\0';
        }

        /// <summary>
        /// 验证两个字串是否有且只有一个字符不同
        /// 题目的意思是abb与bbb结果为true，而aabb与bbbb结果为false，这个方法二者都是true
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="i1"></param>
        /// <param name="s2"></param>
        /// <param name="i2"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private bool IsOneCharDiff_error(string s1, int i1, string s2, int i2, int len)
        {
            char c1 = '\0', c2 = '\0', _c1, _c2;
            for (int i = 0; i < len; i++)
            {
                _c1 = s1[i1 + i]; _c2 = s2[i2 + i];
                if (_c1 != _c2)
                {
                    if (c1 == '\0')
                        (c1, c2) = (_c1, _c2);
                    else if (_c1 != c1 || _c2 != c2)
                        return false;
                }
            }

            return c1 != '\0';
        }
    }
}
