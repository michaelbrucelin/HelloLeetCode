using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2937
{
    public class Solution2937 : Interface2937
    {
        /// <summary>
        /// 遍历
        /// 找公共前缀
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public int FindMinimumOperations(string s1, string s2, string s3)
        {
            int len1 = s1.Length, len2 = s2.Length, len3 = s3.Length;
            int ptr, len = Math.Min(Math.Min(len1, len2), len3);
            for (ptr = 0; ptr < len; ptr++)
            {
                if (s1[ptr] != s2[ptr] || s2[ptr] != s3[ptr]) break;
            }

            if (ptr == 0) return -1;
            return len1 - ptr + len2 - ptr + len3 - ptr;
        }
    }
}
