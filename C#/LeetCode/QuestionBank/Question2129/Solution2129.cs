using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2129
{
    public class Solution2129 : Interface2129
    {
        /// <summary>
        /// 类C的朴素解法，双指针
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public string CapitalizeTitle(string title)
        {
            StringBuilder result = new StringBuilder();
            int len = title.Length, left = 0, right;
            while (left < len)
            {
                right = left + 1;
                while (right < len && title[right] != ' ') right++;
                if (right - left < 3)
                {
                    for (int i = left; i < right; i++) result.Append((char)(title[i] | 32));
                }
                else
                {
                    result.Append((char)(title[left] & -33));
                    for (int i = left + 1; i < right; i++) result.Append((char)(title[i] | 32));
                }

                if (right == len) break;
                result.Append(' ');
                left = right + 1;
            }

            return result.ToString();
        }
    }
}
