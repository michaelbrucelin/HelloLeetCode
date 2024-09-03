using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0844
{
    public class Solution0844_3 : Interface0844
    {
        public bool BackspaceCompare(string s, string t)
        {
            Stack<char> stack_s = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    if (stack_s.Count > 0) stack_s.Pop();
                }
                else
                    stack_s.Push(s[i]);
            }

            Stack<char> stack_t = new Stack<char>();
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == '#')
                {
                    if (stack_t.Count > 0) stack_t.Pop();
                }
                else
                    stack_t.Push(t[i]);
            }
            if (stack_s.Count != stack_t.Count) return false;

            // while (stack_s.Count > 0) if (stack_s.Pop() != stack_t.Pop()) return false;
            // return true;
            return Enumerable.SequenceEqual<char>(stack_s, stack_t);
        }

        /// <summary>
        /// 与BackspaceCompare()一样，使用编码手段精简代码
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool BackspaceCompare2(string s, string t)
        {
            Stack<char> stack_s = new Stack<char>(), stack_t = new Stack<char>();
            Stack<char> stack = stack_s; string str = s; bool repeat = true;
            Repeat:
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '#')
                {
                    if (stack.Count > 0) stack.Pop();
                }
                else
                    stack.Push(str[i]);
            }
            if (repeat)
            {
                stack = stack_t; str = t; repeat = false;
                goto Repeat;
            }
            if (stack_s.Count != stack_t.Count) return false;

            // while (stack_s.Count > 0) if (stack_s.Pop() != stack_t.Pop()) return false;
            // return true;
            return Enumerable.SequenceEqual<char>(stack_s, stack_t);
        }
    }
}
