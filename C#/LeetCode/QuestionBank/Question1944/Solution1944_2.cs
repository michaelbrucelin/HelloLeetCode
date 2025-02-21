using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1944
{
    public class Solution1944_2 : Interface1944
    {
        /// <summary>
        /// 逻辑同Solution1944，但是单调数组stack没有移除无用的项，而是使用一个cnt变量记录有效项的数量
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int[] CanSeePersonsCount(int[] heights)
        {
            int[] result = new int[heights.Length];
            List<int> stack = new List<int>() { heights[^1] };
            int cnt = 1;  // 记录stack的有效项的数量，这样就不需要移除stack中的无用项了
            for (int i = heights.Length - 2, id = 0, height = 0; i >= 0; i--)
            {
                height = heights[i]; id = BinarySearch(stack, cnt, height);
                if (id == -1)
                {
                    result[i] = cnt;
                    stack.Clear();
                    stack.Add(height);
                    cnt = 1;
                }
                else
                {
                    result[i] = cnt - id;
                    // for (int j = stack.Count - 1; j > id; j--) stack.RemoveAt(j);
                    // stack.Add(height);
                    if (id + 1 < stack.Count) stack[id + 1] = height; else stack.Add(height);
                    cnt = id + 2;
                }
            }

            return result;
        }

        private int BinarySearch(List<int> list, int cnt, int target)
        {
            int left = 0, right = cnt - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid] < target) right = mid - 1; else left = mid + 1;
            }

            return right;
        }
    }
}
