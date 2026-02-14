using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0038
{
    public class Solution0038 : Interface0038
    {
        /// <summary>
        /// 单调栈
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        public int[] DailyTemperatures(int[] temperatures)
        {
            if (temperatures.Length == 1) return [0];

            int len = temperatures.Length;
            int[] result = new int[len];
            result[^1] = 0;
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((temperatures[^1], len - 1));
            for (int i = len - 2; i >= 0; i--)
            {
                while (stack.Count > 0 && temperatures[i] >= stack.Peek().Item1) stack.Pop();
                result[i] = stack.Count > 0 ? stack.Peek().Item2 - i : 0;
                stack.Push((temperatures[i], i));
            }

            return result;
        }
    }
}
