using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0809
{
    public class Solution0809_2 : Interface0809
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0809，将递归改为迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            if (n == 0) return [];
            if (n == 1) return ["()"];

            List<string> result = [];
            int N = n << 1;
            char[] init = new char[N];
            Array.Fill(init, ')');

            Stack<(char[], int, int)> stack = new Stack<(char[], int, int)>();
            stack.Push((init, 0, 0));
            while (stack.Count > 0)
            {
                (char[] chars, int lcnt, int rcnt) = stack.Pop();
                if (lcnt == n)
                {
                    result.Add(new string(chars));
                }
                else
                {
                    char[] _chars = new char[N];
                    Array.Copy(chars, _chars, N);
                    _chars[lcnt + rcnt] = '(';
                    stack.Push((_chars, lcnt + 1, rcnt));
                    if (lcnt > rcnt) stack.Push((chars, lcnt, rcnt + 1));
                }
            }

            return result;
        }
    }
}
