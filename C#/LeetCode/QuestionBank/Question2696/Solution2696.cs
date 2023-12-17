using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2696
{
    public class Solution2696 : Interface2696
    {
        /// <summary>
        /// 模拟
        /// 类C的朴素解法
        /// 可以将List<char>改为双向链表的，但是C#中貌似没有内置双向链表，懒得写了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinLength(string s)
        {
            List<char> chars = s.ToList();
            int ptr = 0; while (ptr < chars.Count)
            {
                switch (chars[ptr])
                {
                    case 'A':
                        if (ptr + 1 < chars.Count && chars[ptr + 1] == 'B')
                        {
                            chars.RemoveAt(ptr); chars.RemoveAt(ptr);
                            if (ptr > 0) ptr--;
                            continue;
                        }
                        break;
                    case 'C':
                        if (ptr + 1 < chars.Count && chars[ptr + 1] == 'D')
                        {
                            chars.RemoveAt(ptr); chars.RemoveAt(ptr);
                            if (ptr > 0) ptr--;
                            continue;
                        }
                        break;
                    default:
                        break;
                }
                ptr++;
            }

            return chars.Count;
        }

        /// <summary>
        /// 与MinLength()逻辑一样，将char数组改为栈
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinLength2(string s)
        {
            Stack<char> stack = new Stack<char>(); stack.Push('\0');
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'B':
                        if (stack.Peek() == 'A') { stack.Pop(); continue; }
                        break;
                    case 'D':
                        if (stack.Peek() == 'C') { stack.Pop(); continue; }
                        break;
                    default:
                        break;
                }
                stack.Push(s[i]);
            }

            return stack.Count - 1;
        }
    }
}
