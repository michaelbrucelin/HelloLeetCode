using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1047
{
    public class Solution1047 : Interface1047
    {
        /// <summary>
        /// 数组操作
        /// 只要遇到相同的，删除，并后退一步
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicates4(string s)
        {
            List<char> chars = new List<char>(s);
            int i = 0; while (i < chars.Count - 1)
            {
                if (chars[i] == chars[i + 1])
                {
                    chars.RemoveAt(i + 1); chars.RemoveAt(i);
                    if (i > 0) i--;
                }
                else
                {
                    i++;
                }
            }

            return new string(chars.ToArray());
        }

        /// <summary>
        /// 栈
        /// 逻辑同RemoveDuplicates()，做了一些优化，避免的频繁大量的数组移位
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicates2(string s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (stack.Count > 0 && s[i] == stack.Peek())
                    stack.Pop();
                else
                    stack.Push(s[i]);
            }

            return new string(stack.Reverse().ToArray());
        }

        /// <summary>
        /// StringBuilder
        /// 逻辑同RemoveDuplicates2()，将栈换成StringBuilder
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicates3(string s)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (result.Length > 0 && s[i] == result[^1])
                    result.Remove(result.Length - 1, 1);
                else
                    result.Append(s[i]);
            }

            return result.ToString();
        }

        /// <summary>
        /// LinkedList
        /// 逻辑同RemoveDuplicates2()，将栈换成LinkedList
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string s)
        {
            LinkedList<char> list = new LinkedList<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (list.Count > 0 && s[i] == list.Last.Value)
                    list.RemoveLast();
                else
                    list.AddLast(s[i]);
            }

            return new string(list.ToArray());
        }
    }
}
