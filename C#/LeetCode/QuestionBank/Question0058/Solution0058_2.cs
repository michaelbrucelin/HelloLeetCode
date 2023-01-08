using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0058
{
    public class Solution0058_2 : Interface0058
    {
        /// <summary>
        /// 从后向前遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            int result = 0, ptr = s.Length - 1;
            while (s[ptr] == ' ') ptr--;                            // 题目规定至少含有一个单词，所以不判断ptr >= 0
            while (ptr >= 0 && s[ptr] != ' ') { result++; ptr--; }

            return result;
        }
    }
}
