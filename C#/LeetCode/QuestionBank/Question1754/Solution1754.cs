using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1754
{
    public class Solution1754 : Interface1754
    {
        /// <summary>
        /// 贪心法
        /// 具体见Solution1754.md
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public string LargestMerge(string word1, string word2)
        {
            int len1 = word1.Length, len2 = word2.Length;
            char[] result = new char[len1 + len2];
            int ptr = 0, ptr1 = 0, ptr2 = 0;
            while (ptr1 < len1 && ptr2 < len2)
                if (GreaterEqual(word1, ptr1, word2, ptr2)) result[ptr++] = word1[ptr1++]; else result[ptr++] = word2[ptr2++];
            while (ptr1 < len1) result[ptr++] = word1[ptr1++];
            while (ptr2 < len2) result[ptr++] = word2[ptr2++];

            return new string(result);
        }

        private bool GreaterEqual(string word1, int index1, string word2, int index2)
        {
            int len1 = word1.Length, len2 = word2.Length;
            while (index1 < len1 && index2 < len2)
            {
                if (word1[index1] > word2[index2]) return true;
                if (word1[index1] < word2[index2]) return false;
                index1++; index2++;
            }
            if (index1 < len1) return true;
            if (index2 < len2) return false;

            return true;  // equal
        }
    }
}
