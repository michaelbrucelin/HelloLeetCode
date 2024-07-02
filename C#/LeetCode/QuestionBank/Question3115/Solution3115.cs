using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3115
{
    public class Solution3115 : Interface3115
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumPrimeDifference(int[] nums)
        {
            int left = -1, right = nums.Length;
            while (true) if (IsPrime(nums[++left])) break;   // 题目限定nums中至少有一个质数，所以不会数组越界
            while (true) if (IsPrime(nums[--right])) break;

            return right - left;

            bool IsPrime(int num)
            {
                if (num <= 1) return false;
                if (num == 2) return true;
                if ((num & 1) == 0) return false;

                int boundary = (int)Math.Floor(Math.Sqrt(num));
                for (int i = 3; i <= boundary; i += 2) if (num % i == 0) return false;

                return true;
            }
        }
    }
}
