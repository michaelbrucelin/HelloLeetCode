using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1859
{
    public class Solution1859 : Interface1859
    {
        /// <summary>
        /// 类C的朴素解法，双指针 + 桶排序
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SortSentence(string s)
        {
            string[] buffer = new string[9];
            int len = s.Length, p1 = 0, p2;
            while (p1 < len)
            {
                p2 = p1 + 2;
                while (p2 < len && s[p2] != ' ') p2++;
                buffer[s[p2 - 1] - '1'] = s.Substring(p1, p2 - p1 - 1);
                p1 = p2 + 1;
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 9 && buffer[i] != null; i++)
                result.Append($"{buffer[i]} ");

            return result.ToString(0, result.Length - 1);
        }
    }
}
