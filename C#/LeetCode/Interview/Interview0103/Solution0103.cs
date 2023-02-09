using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0103
{
    public class Solution0103 : Interface0103
    {
        /// <summary>
        /// 模拟C中的操作
        /// </summary>
        /// <param name="S"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string ReplaceSpaces(string S, int length)
        {
            char[] result = new char[S.Length];
            int ptr = S.Length - 1;
            for (int i = length - 1; i >= 0; i--)
            {
                if (S[i] != ' ')
                {
                    result[ptr--] = S[i];
                }
                else
                {
                    result[ptr--] = '0'; result[ptr--] = '2'; result[ptr--] = '%';
                }
            }

            return new string(result, ptr + 1, S.Length - ptr - 1);
        }

        public string ReplaceSpaces2(string S, int length)
        {
            List<char> result = new List<char>();
            for (int i = 0; i < length; i++)
            {
                if (S[i] != ' ')
                {
                    result.Add(S[i]);
                }
                else
                {
                    result.Add('%'); result.Add('2'); result.Add('0');
                }
            }

            return new string(result.ToArray());
        }

        public string ReplaceSpaces3(string S, int length)
        {
            return string.Join("", S.Take(length).Select(c => c != ' ' ? c.ToString() : "%20"));
        }
    }
}
