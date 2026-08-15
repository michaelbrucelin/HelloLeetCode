using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1541
{
    public class Solution1541_err : Interface1541
    {
        /// <summary>
        /// 栈
        /// 倒序更好处理
        /// 
        /// 逻辑错误，参考测试用例06
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinInsertions(string s)
        {
            int result = 0;
            Stack<char> stack = new Stack<char>();
            char c;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if ((c = s[i]) == '(')
                {
                    switch (stack.Count - 1)
                    {
                        case > 0: stack.Pop(); stack.Pop(); break;
                        case < 0: result += 2; break;
                        default: stack.Pop(); result++; break;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            result += ((stack.Count + 1) >> 1) + (stack.Count & 1);

            return result;
        }
    }
}
