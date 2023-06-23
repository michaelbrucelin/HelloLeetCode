using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2206
{
    public class Solution2206 : Interface2206
    {
        /// <summary>
        /// 原始暴力的计数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool DivideArray(int[] nums)
        {
            int[] cnt = new int[501];
            for (int i = 0; i < nums.Length; i++) cnt[nums[i]]++;

            for (int i = 1; i <= 500; i++) if ((cnt[i] & 1) != 0) return false;
            return true;
        }

        /// <summary>
        /// 与DivideArray()一样，将数组改为Hash表
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool DivideArray2(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
                if (set.Contains(num)) set.Remove(num); else set.Add(num);

            return set.Count == 0;
        }
    }
}
