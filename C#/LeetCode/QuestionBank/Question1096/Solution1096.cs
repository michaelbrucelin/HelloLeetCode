using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1096
{
    public class Solution1096 : Interface1096
    {
        /// <summary>
        /// 逆波兰表达式解法
        /// 具体见Solution1096.md
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IList<string> BraceExpansionII(string expression)
        {
            #region 将中缀表达式转为后缀表达式
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();
            List<string> exp = SplitAndKeep(expression, new char[] { ',', '{', '}' });
            for (int i = 0; i < exp.Count; i++)
            {
                switch (exp[i])
                {
                    case "{":
                        if (i != 0 && exp[i - 1] != "{" && exp[i - 1] != ",") stack.Push("*");
                        stack.Push("{");
                        break;
                    case ",":
                        while (stack.Count > 0 && stack.Peek() == "*") queue.Enqueue(stack.Pop());
                        stack.Push("+");
                        break;
                    case "}":
                        while (stack.Count > 0 && stack.Peek() != "{") queue.Enqueue(stack.Pop());
                        if (stack.Count > 0) stack.Pop();
                        break;
                    default:  // 小写字母
                        if (i != 0 && exp[i - 1] != "{" && exp[i - 1] != ",") stack.Push("*");
                        queue.Enqueue(exp[i]);
                        break;
                }
            }
            while (stack.Count > 0) queue.Enqueue(stack.Pop());
            #endregion

            #region 利用后缀表达式计算结果
            Stack<SortedSet<string>> result = new Stack<SortedSet<string>>();
            while (queue.Count > 0)
            {
                string item = queue.Dequeue();
                if (item != "+" && item != "*") result.Push(new SortedSet<string>() { item });
                else
                {
                    SortedSet<string> set2 = result.Pop(), set1 = result.Pop(), _set = new SortedSet<string>();
                    if (item == "+")
                    {
                        _set.UnionWith(set1); _set.UnionWith(set2);
                    }
                    else
                    {
                        foreach (string s1 in set1) foreach (string s2 in set2) _set.Add($"{s1}{s2}");
                    }
                    result.Push(_set);
                }
            }
            #endregion

            return result.Pop().ToArray();
        }

        private List<string> SplitAndKeep(string s, char[] delims)
        {
            List<string> result = new List<string>();

            int start = 0, index;
            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0) result.Add(s.Substring(start, index - start));
                result.Add(s.Substring(index, 1));
                start = index + 1;
            }
            if (start < s.Length) result.Add(s.Substring(start));

            return result;
        }
    }
}
