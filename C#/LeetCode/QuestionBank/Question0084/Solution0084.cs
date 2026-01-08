using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0084
{
    public class Solution0084 : Interface0084
    {
        /// <summary>
        /// 贡献法 + 单调栈
        /// 枚举每一块板，假定这块板就是矩形的高，找最大的宽即可
        ///     找左侧第一块高度更小的板
        ///     找右侧第一块高度更小的板
        /// 上述两个查找过程可以用单调栈预处理出来，参考Question0739
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea(int[] heights)
        {
            int len = heights.Length;
            Stack<(int, int)> stack = new Stack<(int, int)>();
            int[] short_l = new int[len];
            stack.Push((-1, -1));
            for (int i = 0, height; i < len; i++)
            {
                height = heights[i];
                while (height <= stack.Peek().Item1) stack.Pop();
                short_l[i] = i - stack.Peek().Item2;
                stack.Push((height, i));
            }
            stack.Clear();
            int[] short_r = new int[len];
            stack.Push((-1, len));
            for (int i = len - 1, height; i >= 0; i--)
            {
                height = heights[i];
                while (stack.Peek().Item1 >= height) stack.Pop();
                short_r[i] = stack.Peek().Item2 - i;
                stack.Push((height, i));
            }

            int result = 0;
            for (int i = 0; i < len; i++) result = Math.Max(result, (short_l[i] + short_r[i] - 1) * heights[i]);
            return result;
        }
    }
}
