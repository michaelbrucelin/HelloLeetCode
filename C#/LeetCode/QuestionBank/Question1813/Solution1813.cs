using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1813
{
    public class Solution1813 : Interface1813
    {
        /// <summary>
        /// 如果长度一致，两个字符串必须相等
        /// 如果一长一短，必须向短的字符串中插入，短的需要是长的开头，或结尾，或两端
        /// </summary>
        /// <param name="sentence1"></param>
        /// <param name="sentence2"></param>
        /// <returns></returns>
        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            int len1 = sentence1.Length, len2 = sentence2.Length;
            if (len1 == len2) return sentence1 == sentence2;
            if (len1 < len2)  // 始终向sentence2中插入
            {
                string t = sentence1; sentence1 = sentence2; sentence2 = t;
                len1 = len1 ^ len2; len2 = len1 ^ len2; len1 = len1 ^ len2;
            }

            int ptr1 = 0, ptr2 = 0;
            while (ptr2 < len2) if (sentence2[ptr2] != sentence1[ptr1]) break; else { ptr1++; ptr2++; }
            if (ptr2 == len2 && sentence1[ptr1] == ' ') return true;
            bool isprev = ptr2 == 0 ? false : sentence2[ptr2 - 1] == ' ';
            int previd = ptr2 - 1;

            ptr1 = len1 - 1; ptr2 = len2 - 1;
            while (ptr2 >= 0) if (sentence2[ptr2] != sentence1[ptr1]) break; else { ptr1--; ptr2--; }
            if (ptr2 == -1 && sentence1[ptr1] == ' ') return true;
            bool ispost = ptr2 == len2 - 1 ? false : sentence2[ptr2 + 1] == ' ';
            int postid = ptr2 + 1;

            return isprev && ispost && previd >= postid;
        }
    }
}
