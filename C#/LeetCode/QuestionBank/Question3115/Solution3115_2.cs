using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3115
{
    public class Solution3115_2 : Interface3115
    {
        public Solution3115_2()
        {
            primes = new HashSet<int>();
            for (int i = 1; i < 101; i++) if (IsPrime(i)) primes.Add(i);
        }

        private HashSet<int> primes;

        /// <summary>
        /// 打表
        /// 题目限定num <= 100，但是nums的长度可以达到3*10^5，显然打表是个不错的方法
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

        private static bool IsPrime(int num)
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
