using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0647
{
    public class Solution0647 : Interface0647
    {
        /// <summary>
        /// 暴力枚举
        /// 从中心向两边枚举
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountSubstrings(string s)
        {
            int result = 0, len = s.Length;

            // 枚举奇数长度
            for (int i = 0, offset; i < len; i++)
            {
                offset = 1;
                while (i - offset >= 0 && i + offset < len && s[i - offset] == s[i + offset]) offset++;
                result += offset;
            }

            // 枚举偶数长度
            for (int i = 0, j = 1, offset; j < len; i++, j++) if (s[i] == s[j])
                {
                    offset = 1;
                    while (i - offset >= 0 && j + offset < len && s[i - offset] == s[j + offset]) offset++;
                    result += offset;
                }

            return result;
        }
    }
}
