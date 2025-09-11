using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0215
{
    public class Solution0215 : Interface0215
    {
        /// <summary>
        /// 计数排序
        /// 题目要求O(n)的时间复杂度，所以这里使用计数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            int min = int.MaxValue, max = int.MinValue;
            foreach (int num in nums) { min = Math.Min(min, num); max = Math.Max(max, num); }
            int[] freq = new int[max - min + 1];
            foreach (int num in nums) freq[num - min]++;

            for (int i = freq.Length - 1; i >= 0; i--) if ((k -= freq[i]) <= 0) return i + min;
            throw new Exception("logic error");
        }
    }
}
