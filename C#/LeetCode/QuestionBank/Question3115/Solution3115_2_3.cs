using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LeetCode.QuestionBank.Question3115
{
    public class Solution3115_2_3 : Interface3115
    {
        private readonly static HashSet<int> primes = new HashSet<int>() {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        /// <summary>
        /// 纯血打表
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumPrimeDifference(int[] nums)
        {
            int left = -1, right = nums.Length;
            while (true) if (primes.Contains(nums[++left])) break;   // 题目限定nums中至少有一个质数，所以不会数组越界
            while (true) if (primes.Contains(nums[--right])) break;

            return right - left;
        }
    }
}
