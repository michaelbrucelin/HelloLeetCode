using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3115
{
    public class Solution3115_2_2 : Interface3115
    {
        public Solution3115_2_2()
        {
            primes = new HashSet<int>(GetPrimes(101));
        }

        private HashSet<int> primes;

        /// <summary>
        /// 打表
        /// 逻辑同Solution3115_2，预处理过程使用线性筛
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

        private static List<int> GetPrimes(int n)
        {
            List<int> result = new List<int>();
            bool[] mask = new bool[n]; Array.Fill(mask, true);
            for (int i = 2; i < n; i++)
            {
                if (mask[i]) result.Add(i);
                for (int j = 0; j < result.Count && i * result[j] < n; j++)
                {
                    mask[i * result[j]] = false;
                    if (i % result[j] == 0) break;
                }
            }

            return result;
        }
    }
}
