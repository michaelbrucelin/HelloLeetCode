using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1805
{
    public class Solution1805 : Interface1805
    {
        /// <summary>
        /// 三指针
        /// 采用类似于C的朴素的方式解
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int NumDifferentIntegers(string word)
        {
            HashSet<string> result = new HashSet<string>();
            int ptr = -1, left = -1, right = -1, not_zero = -1;  // 每一段开头索引，结尾索引，第一个非0索引
            while (++ptr < word.Length)
            {
                if (!char.IsDigit(word[ptr]))
                {
                    if (left != -1)
                    {
                        if (not_zero == -1) result.Add("0");
                        else result.Add(word.Substring(not_zero, right - not_zero + 1));
                        left = -1; right = -1; not_zero = -1;
                    }
                }
                else  // if (char.IsDigit(word[ptr]))
                {
                    if (left == -1) left = ptr;
                    if (not_zero == -1 && word[ptr] != '0') not_zero = ptr;
                    right = ptr;
                }
            }

            if (left != -1)
            {
                if (not_zero == -1) result.Add("0");
                else result.Add(word.Substring(not_zero, right - not_zero + 1));
            }

            return result.Count;
        }
    }
}
