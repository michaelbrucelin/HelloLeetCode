using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0394
{
    public class Solution0394 : Interface0394
    {
        /// <summary>
        /// 栈
        /// 本质上就是找匹配的括号，遇到数字与字母入栈，遇到右括号出栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeString(string s)
        {
            StringBuilder result = new StringBuilder();
            Stack<int> cnts = new Stack<int>();
            Stack<string> strs = new Stack<string>();
            int ptr = -1, cnt = 0, pl = 0, pr = -1, len = s.Length;
            char c;
            while (++ptr < len)
            {
                c=s[ptr];

            }

            return result.ToString();
        }
    }
}
