using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1071
{
    public class Solution1071 : Interface1071
    {
        /// <summary>
        /// 分析
        /// 1. 找出str1与str2最长的公共前缀pre，答案一定是pre的前缀
        /// 2. 验证
        ///     1. 验证长度能不能整除
        ///     2. 先验证是不是短字符串的因子，再验证是不是长字符串的因子
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public string GcdOfStrings(string str1, string str2)
        {
            if (str1.Length > str2.Length) (str1, str2) = (str2, str1);  // 小驱动大
            int len1 = str1.Length, len2 = str2.Length, ptr = -1;
            while (ptr + 1 < len1 && ptr + 1 < len2 && str1[ptr + 1] == str2[ptr + 1]) ptr++;
            for (int i = ptr + 1; i > 0; i--)
            {
                if (IsCDOfStrings(str1, i) && IsCDOfStrings(str2, i))
                    return str1.Substring(0, i);
            }

            return string.Empty;
        }

        /// <summary>
        /// 验证str的长度为lsub的前缀，是不是str的因子
        /// </summary>
        /// <param name="str"></param>
        /// <param name="lsub"></param>
        /// <returns></returns>
        private bool IsCDOfStrings(string str, int lsub)
        {
            int lstr = str.Length;
            if (lsub == 0 || lstr == 0 || lstr % lsub != 0) return false;  // 这里不考虑空字符串

            for (int i = 0; i < lsub; i++) for (int j = 1; j < lstr / lsub; j++)
                {
                    if (str[i] != str[lsub * j + i]) return false;
                }
            return true;
        }
    }
}
