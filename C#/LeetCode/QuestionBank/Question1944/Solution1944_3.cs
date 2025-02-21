using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1944
{
    public class Solution1944_3 : Interface1944
    {
        /// <summary>
        /// 单调栈
        /// 本质上逻辑同Solution1944，单调栈理解的还是不够通透，写完Solution1944才想明白可以直接使用单调栈
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int[] CanSeePersonsCount(int[] heights)
        {
            int[] result = new int[heights.Length];
            Stack<int> stack = new Stack<int>();
            stack.Push(heights[^1]);
            for (int i = heights.Length - 2, cnt = 0, height = 0; i >= 0; i--)
            {
                cnt = 0; height = heights[i];
                while (stack.Count > 0 && stack.Peek() < height)
                {
                    stack.Pop(); cnt++;
                }
                if (stack.Count > 0) cnt++;
                result[i] = cnt;
                stack.Push(height);
            }

            return result;
        }
    }
}
