using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2109
{
    public class Solution2109 : Interface2109
    {
        /// <summary>
        /// 三指针
        /// </summary>
        /// <param name="s"></param>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public string AddSpaces(string s, int[] spaces)
        {
            int len1 = s.Length, len2 = spaces.Length, len = s.Length + spaces.Length;
            char[] result = new char[len];
            for (int i = 0; i < len2; i++) spaces[i] += i;
            for (int i = 0, p1 = 0, p2 = 0; i < len; i++)
            {
                if (p2 < len2 && i == spaces[p2])
                {
                    result[i] = ' '; p2++;
                }
                else
                {
                    result[i] = s[p1]; p1++;
                }
            }

            return new string(result);
        }

        /// <summary>
        /// 逻辑同AddSpaces()，从后向前再来一次
        /// </summary>
        /// <param name="s"></param>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public string AddSpaces2(string s, int[] spaces)
        {
            int len1 = s.Length, len2 = spaces.Length;
            char[] result = new char[len1 + len2];
            for (int i = 0; i < len2; i++) spaces[i] += i;
            for (int i = len1 + len2 - 1, p1 = len1 - 1, p2 = len2 - 1; i >= 0; i--)
            {
                if (p2 >= 0 && i == spaces[p2])
                {
                    result[i] = ' '; p2--;
                }
                else
                {
                    result[i] = s[p1]; p1--;
                }
            }

            return new string(result);
        }
    }
}
