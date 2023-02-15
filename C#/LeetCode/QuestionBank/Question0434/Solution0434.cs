using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0434
{
    public class Solution0434 : Interface0434
    {
        /// <summary>
        /// 统计空格的数量
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountSegments(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left <= right && s[left] == ' ') left++;    // 忽略开头的空格
            while (right >= left && s[right] == ' ') right--;  // 忽略结尾的空格
            if (left > right) return 0;

            int result = 1;
            for (int i = left + 1; i <= right - 1; i++)
            {
                if (s[i] == ' ' && s[i - 1] != ' ') result++;
            }

            return result;
        }

        public int CountSegments2(string s)
        {
            return s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public int CountSegments3(string s)
        {
            // return Regex.Replace(s.Trim(), @" +", " ").Count(c => c == ' ') + 1;
            return -1;  // 错的，不修正了
        }
    }
}
