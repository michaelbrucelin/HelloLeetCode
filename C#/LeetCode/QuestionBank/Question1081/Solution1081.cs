using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1081
{
    public class Solution1081 : Interface1081
    {
        /// <summary>
        /// 贪心 + 栈
        /// 遍历s的每一个字符，假定当前字符是char
        /// 如果栈中已经有了char，跳过
        /// 否则，如果char > 栈顶，char入栈
        ///       如果char < 栈顶，如果s的后边还有栈顶字符，弹栈，反复直到栈顶元素小于char，入栈
        /// 使用一个集合记录stack是否包含字母，预处理每个字母在s中最后出现的位置
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SmallestSubsequence(string s)
        {
            Stack<char> stack = new Stack<char>();
            int mask = 0, len = s.Length; char c, _c;
            int[] lastpos = new int[26];
            for (int i = 0; i < len; i++) lastpos[s[i] - 'a'] = i;
            for (int i = 0, offset; i < len; i++)
            {
                offset = (c = s[i]) - 'a';
                if (((mask >> offset) & 1) != 0) continue;
                mask |= 1 << offset;
                while (stack.Count > 0 && (_c = stack.Peek()) > c)
                {
                    offset = _c - 'a';
                    if (lastpos[offset] > i)
                    {
                        stack.Pop(); mask ^= 1 << offset;
                    }
                    else
                    {
                        break;
                    }
                }
                stack.Push(c);
            }

            len = stack.Count;
            char[] result = new char[len];
            for (int i = len - 1; i >= 0; i--) result[i] = stack.Pop();
            return new string(result);
        }
    }
}
