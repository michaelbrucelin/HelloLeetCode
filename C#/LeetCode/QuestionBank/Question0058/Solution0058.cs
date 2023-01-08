using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0058
{
    public class Solution0058 : Interface0058
    {
        /// <summary>
        /// 从前向后遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            int result = -1;
            int ptr = -1, len = s.Length;
            while (++ptr < len)
            {
                if (s[ptr] == ' ') continue;
                int _len = 1;
                while (++ptr < len && s[ptr] != ' ') _len++;
                result = _len;
            }

            return result;
        }

        public int LengthOfLastWord2(string s)
        {
            return s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Last().Length;
        }
    }
}
