using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3561
{
    public class Solution3561 : Interface3561
    {
        /// <summary>
        /// 模拟
        /// 使用栈模拟
        /// 
        /// 还是List<char>与StringBuilder快
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ResultingString(string s)
        {
            if (s.Length == 1) return s;

            Stack<char> stack = [];
            int diff, len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    diff = Math.Abs(s[i] - stack.Peek());
                    if (diff == 1 || diff == 25) stack.Pop(); else stack.Push(s[i]);
                }
            }

            return new string([.. stack.Reverse()]);
        }

        /// <summary>
        /// 使用列表模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ResultingString2(string s)
        {
            if (s.Length == 1) return s;

            List<char> list = [];
            int p = 0, diff, len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (p == 0)
                {
                    if (p == list.Count) list.Add(s[i]); else list[p] = s[i];
                    p++;
                }
                else
                {
                    diff = Math.Abs(s[i] - list[p - 1]);
                    if (diff == 1 || diff == 25) p--; else { if (p == list.Count) list.Add(s[i]); else list[p] = s[i]; p++; }
                }
            }

            return new string([.. list[..p]]);
        }

        /// <summary>
        /// 改为链表模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ResultingString3(string s)
        {
            if (s.Length == 1) return s;

            LinkedList<char> list = [];
            int diff, len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (list.Count == 0)
                {
                    list.AddLast(s[i]);
                }
                else
                {
                    diff = Math.Abs(s[i] - list.Last.Value);
                    if (diff == 1 || diff == 25) list.RemoveLast(); else list.AddLast(s[i]);
                }
            }

            return new string([.. list]);
        }

        /// <summary>
        /// 使用StringBuilder模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ResultingString4(string s)
        {
            if (s.Length == 1) return s;

            StringBuilder sb = new StringBuilder();
            int diff, len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (sb.Length == 0)
                {
                    sb.Append(s[i]);
                }
                else
                {
                    diff = Math.Abs(s[i] - sb[^1]);
                    if (diff == 1 || diff == 25) sb.Length--; else sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }
    }
}
