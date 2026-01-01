using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3769
{
    public class Solution3769 : Interface3769
    {
        /// <summary>
        /// 自定义排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortByReflection(int[] nums)
        {
            int len = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>() { { 0, 0 } };
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < len; i++) if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], BinaryReverse(nums[i]));
                }

            Array.Sort(nums, (x, y) => map[x] != map[y] ? map[x] - map[y] : x - y);
            return nums;

            int BinaryReverse(int x)
            {
                int digit;
                while (x > 0)
                {
                    digit = x & 1;
                    if (digit != 0 || queue.Count > 0) queue.Enqueue(digit);
                    x >>= 1;
                }

                while (queue.Count > 0) x = (x << 1) | queue.Dequeue();
                return x;
            }
        }
    }
}
