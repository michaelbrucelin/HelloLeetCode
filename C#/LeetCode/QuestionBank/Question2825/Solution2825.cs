using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2825
{
    public class Solution2825 : Interface2825
    {
        /// <summary>
        /// 贪心 + 双指针
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public bool CanMakeSubsequence(string str1, string str2)
        {
            if (str1.Length < str2.Length) return false;

            int p1 = -1, p2 = 0, len1 = str1.Length, len2 = str2.Length;
            while (++p1 < len1 && p2 < len2)
            {
                if (str1[p1] == str2[p2] || str1[p1] + 1 == str2[p2] || (str1[p1] == 'z' && str2[p2] == 'a')) p2++;
            }

            return p2 == len2;
        }
    }
}
