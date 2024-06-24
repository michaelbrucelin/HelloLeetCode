using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0503
{
    public class Solution0503_3 : Interface0503
    {
        public int[] NextGreaterElements(int[] nums)
        {
            if (nums.Length == 1) return [-1];

            int max = nums[0], len = nums.Length;
            int[] result = new int[len];
            Stack<int> stack = new Stack<int>();
            for (int k = 0; k < 2; k++) for (int i = 0; i < len; i++)
                {
                    max = Math.Max(max, nums[i]);
                    while (stack.Count > 0 && nums[i] > nums[stack.Peek()])
                    {
                        result[stack.Pop()] = nums[i];
                    }
                    stack.Push(i);
                }
            while (stack.Count > 0)
            {
                if (nums[stack.Peek()] == max) result[stack.Pop()] = -1; else stack.Pop();
            }

            return result;
        }
    }
}
