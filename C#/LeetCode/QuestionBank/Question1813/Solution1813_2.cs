using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1813
{
    public class Solution1813_2 : Interface1813
    {
        /// <summary>
        /// 与Solution1813思路一致，但是分析的不是字符，而是拆分为数组进行分析
        /// </summary>
        /// <param name="sentence1"></param>
        /// <param name="sentence2"></param>
        /// <returns></returns>
        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            if (sentence1.Length == sentence2.Length) return sentence1 == sentence2;

            string[] words1 = sentence1.Split(' '), words2 = sentence2.Split(' ');
            int len1 = words1.Length, len2 = words2.Length;
            if (len1 == len2) return false;  // 到这里字符串长度必然不等，所以单词数相同结果必然是false，反证法即可证明
            if (len1 < len2)                 // 始终向sentence2中插入
            {
                string[] t = words1; words1 = words2; words2 = t;
                len1 = len1 ^ len2; len2 = len1 ^ len2; len1 = len1 ^ len2;
            }

            int ptr1 = 0, ptr2 = 0;
            while (ptr2 < len2) if (words2[ptr2] != words1[ptr1]) break; else { ptr1++; ptr2++; }
            if (ptr2 == len2) return true;
            bool isprev = ptr2 != 0;
            int previd = ptr2 - 1;

            ptr1 = len1 - 1; ptr2 = len2 - 1;
            while (ptr2 >= 0) if (words2[ptr2] != words1[ptr1]) break; else { ptr1--; ptr2--; }
            if (ptr2 == -1) return true;
            bool ispost = ptr2 != len2 - 1;
            int postid = ptr2 + 1;

            return isprev && ispost && previd + 1 >= postid;
        }
    }
}
