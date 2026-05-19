using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1209
{
    public class Solution1209_2 : Interface1209
    {
        /// <summary>
        /// 模拟
        /// 使用栈模拟
        /// 
        /// 逻辑一模一样，甚至还多了一步操作（反转栈），但是速度却快多了，显然C#中的双链表的开销比栈大多了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string s, int k)
        {
            if (k == 1) return "";
            if (s.Length == 1) return s;

            Stack<(char, int)> stack = new Stack<(char, int)>();
            char chr = '\0', c; int cnt = -1, len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if ((c = s[i]) == chr)
                {
                    cnt++;
                }
                else
                {
                    if ((cnt %= k) != 0)
                    {
                        stack.Push((chr, cnt));
                        chr = c; cnt = 1;
                    }
                    else
                    {
                        if (c == stack.Peek().Item1)
                        {
                            (chr, cnt) = stack.Pop();
                            cnt++;
                        }
                        else
                        {
                            chr = c; cnt = 1;
                        }
                    }
                }
            }
            cnt %= k;
            stack.Push((chr, cnt));
            (char, int)[] _stack = stack.ToArray();

            StringBuilder buffer = new StringBuilder();
            for (int i = _stack.Length - 2; i >= 0; i--)
            {
                (chr, cnt) = _stack[i];
                for (int j = 0; j < cnt; j++) buffer.Append(chr);
            }

            return buffer.ToString();
        }
    }
}
