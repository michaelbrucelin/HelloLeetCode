using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1944
{
    public class Solution1944 : Interface1944
    {
        /// <summary>
        /// 二分法 + 单调数组（类单调栈）
        /// 具体分析见Solution1944.md
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int[] CanSeePersonsCount(int[] heights)
        {
            int[] result = new int[heights.Length];
            List<int> stack = new List<int>() { heights[^1] };
            for (int i = heights.Length - 2, id = 0, height = 0; i >= 0; i--)
            {
                height = heights[i]; id = BinarySearch(stack, height);
                if (id == -1)
                {
                    result[i] = stack.Count;
                    stack.Clear();
                    stack.Add(height);
                }
                else
                {
                    result[i] = stack.Count - id;
                    for (int j = stack.Count - 1; j > id; j--) stack.RemoveAt(j);  // j >= 0 && stack[j] < height，这样也可以
                    stack.Add(height);
                }
            }

            return result;
        }

        private int BinarySearch(List<int> list, int target)
        {
            int left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid] < target) right = mid - 1; else left = mid + 1;
            }

            return right;
        }
    }
}
