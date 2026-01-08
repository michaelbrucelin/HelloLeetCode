using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0739
{
    public class Solution0739 : Interface0739
    {
        /// <summary>
        /// 单调栈
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        public int[] DailyTemperatures(int[] temperatures)
        {
            int len = temperatures.Length;
            int[] result = new int[len];
            Stack<(int, int)> stack = new Stack<(int, int)>();
            for (int i = len - 1, val; i >= 0; i--)
            {
                val = temperatures[i];
                while (stack.Count > 0 && val >= stack.Peek().Item1) stack.Pop();
                result[i] = stack.Count > 0 ? stack.Peek().Item2 - i : 0;
                stack.Push((val, i));
            }

            return result;
        }
    }
}
