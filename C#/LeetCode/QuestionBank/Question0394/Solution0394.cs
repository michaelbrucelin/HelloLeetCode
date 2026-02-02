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
        /// 栈，状态机
        /// 本质上就是找匹配的括号，遇到数字与字母入栈，遇到右括号出栈
        /// 
        /// 不算难，但是易错，情况比较多
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeString(string s)
        {
            StringBuilder result = new StringBuilder();
            Stack<int> times = new Stack<int>();
            Stack<(int, int)> strs = new Stack<(int, int)>();
            int ptr = -1, time = 0, pl = 0, pr = 0, lcnt = 0, rcnt = 0, len = s.Length;
            char c;
            while (++ptr < len)
            {
                c = s[ptr];
                if (char.IsDigit(c))
                {
                    if (lcnt == rcnt && pr > pl) { result.Append(s[pl..pr]); time = c - '0'; } else time = time * 10 + c - '0';
                }
                else if (char.IsLetter(c))
                {
                    pr++;
                }
                else if (c == '[')
                {
                    lcnt++;
                    times.Push(time);
                    if (char.IsLetter(s[ptr + 1])) pl = pr = ptr + 1;
                }
                else  // if (c == ']')
                {
                    rcnt++;
                    if (rcnt == lcnt)
                    {
                        StringBuilder buffer = new StringBuilder();
                        string _str = "";
                        while (strs.Count > 0)
                        {
                            (int l, int r) = strs.Pop();
                            _str = $"{_str}{s[l..r]}";
                            for (int i = times.Pop(); i > 0; i--) buffer.Append(_str);
                        }
                    }
                    else  // if (rcnt < lcnt)
                    { 
                    
                    }
                    if (ptr + 1 < len && char.IsLetter(s[ptr + 1])) pl = pr = ptr + 1;
                }
            }

            return result.ToString();
        }
    }
}
