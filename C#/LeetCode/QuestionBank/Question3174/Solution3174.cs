using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3174
{
    public class Solution3174 : Interface3174
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ClearDigits(string s)
        {
            List<char> buffer = new List<char>();
            for (int i = s.Length - 1, j = 0; i >= 0; i--)
            {
                if (char.IsAsciiDigit(s[i]))
                {
                    j++;
                }
                else
                {
                    if (j > 0) j--; else buffer.Add(s[i]);
                }
            }

            buffer.Reverse();
            return new string(buffer.ToArray());
        }
    }
}
