using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3903
{
    public class Solution3903_2 : Interface3903
    {
        /// <summary>
        /// 单调栈
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FirstStableIndex(int[] nums, int k)
        {
            int len = nums.Length;
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((nums[len - 1], len - 1));
            for (int i = len - 2, num; i >= 0; i--)
            {
                num = nums[i];
                if (num < stack.Peek().Item1) stack.Push((num, i));
            }

            int max = nums[0];
            for (int i = 0; i < len; i++)
            {
                max = Math.Max(max, nums[i]);
                while (stack.Peek().Item2 < i) stack.Pop();
                if (max - stack.Peek().Item1 <= k) return i;
            }

            return -1;
        }

        /// <summary>
        /// 预处理
        /// 本质上逻辑与FirstStableIndex()，预处理出后缀数组的最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FirstStableIndex2(int[] nums, int k)
        {
            int len = nums.Length;
            int[] mins = new int[len];
            mins[len - 1] = nums[len - 1];
            for (int i = len - 2; i >= 0; i--) mins[i] = Math.Min(mins[i + 1], nums[i]);

            int max = nums[0];
            for (int i = 0; i < len; i++)
            {
                max = Math.Max(max, nums[i]);
                if (max - mins[i] <= k) return i;
            }

            return -1;
        }
    }
}
