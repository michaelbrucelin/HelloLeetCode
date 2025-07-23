using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1717
{
    public class Solution1717_3 : Interface1717
    {
        /// <summary>
        /// 栈
        /// 思路与Solution1717完全一样，但是不会真的操作删除动作，而是使用栈模拟
        /// 如果先删除ab，再删除ba，则
        ///     遍历s
        ///     如果是a，入栈
        ///     如果是b，
        ///         如果栈顶是a，出栈，计分
        ///         如果栈空，或栈顶是b，入栈
        ///     如果是其它字符
        ///         如果栈非空，则栈中的元素应该是 a 的形式，将全部元素弹出，可以有 Min(Count(a), Count(b)) 个ba，计分
        ///                                        a
        ///                                        b
        ///                                        b
        /// 一定程度上还可以优化空间复杂度，即将栈 a 记为 a,2 的形式，这里就不完善了
        ///                                        a      b,2
        ///                                        b
        ///                                        b
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int MaximumGain(string s, int x, int y)
        {
            char c1, c2; int score1, score2;
            if (x >= y) { c1 = 'a'; c2 = 'b'; score1 = x; score2 = y; } else { c1 = 'b'; c2 = 'a'; score1 = y; score2 = x; }

            int result = 0; int[] cnts = new int[2];
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == c1)
                {
                    stack.Push(c);
                }
                else if (c == c2)
                {
                    if (stack.Count > 0)
                    {
                        if (stack.Peek() == c1)
                        {
                            result += score1;
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(c);
                        }
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        Array.Fill(cnts, 0);
                        while (stack.Count > 0) cnts[stack.Pop() - 'a']++;
                        result += Math.Min(cnts[0], cnts[1]) * score2;
                    }
                }
            }
            if (stack.Count > 0)
            {
                Array.Fill(cnts, 0);
                while (stack.Count > 0) cnts[stack.Pop() - 'a']++;
                result += Math.Min(cnts[0], cnts[1]) * score2;
            }

            return result;
        }
    }
}
