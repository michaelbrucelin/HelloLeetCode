using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1957
{
    public class Solution1957 : Interface1957
    {
        /// <summary>
        /// 模拟
        /// 本质上就是将连续超过4个的相同字符改成2个
        /// TLE，参考测试用例04
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeFancyString3(string s)
        {
            List<char> chars = s.ToList();
            for (int i = chars.Count - 1; i >= 2; i--)
            {
                if (chars[i] == chars[i - 1] && chars[i] == chars[i - 2]) chars.RemoveAt(i);
            }
            return new string(chars.ToArray());
        }

        /// <summary>
        /// 逻辑同MakeFancyString()，只是将list改为了链表
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeFancyString2(string s)
        {
            LinkedList<char> chars = new LinkedList<char>(s);

            LinkedListNode<char> ptr = chars.First.Next;
            while (ptr != null)
            {
                if (ptr.Value == ptr.Previous.Value && ptr.Next != null && ptr.Value == ptr.Next.Value)
                {
                    chars.Remove(ptr.Previous);
                }
                ptr = ptr.Next;
            }

            return new string(chars.ToArray());
        }

        /// <summary>
        /// 逻辑同MakeFancyString()，但是思路反过来了，不是将重复删除，而不将不重复的添加
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeFancyString(string s)
        {
            if (s.Length <= 2) return s;

            List<char> chars = new List<char>() { s[0], s[1] };
            for (int i = 2; i < s.Length; i++)
            {
                if (s[i] != chars[^1] || s[i] != chars[^2]) chars.Add(s[i]);
            }
            return new string(chars.ToArray());
        }
    }
}
