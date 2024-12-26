using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3083
{
    public class Solution3083 : Interface3083
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsSubstringPresent(string s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1] || s.Contains($"{s[i]}{s[i - 1]}")) return true;
            }

            return false;
        }
    }
}
