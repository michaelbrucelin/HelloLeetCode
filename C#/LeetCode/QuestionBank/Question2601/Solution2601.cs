using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2601
{
    public class Solution2601 : Interface2601
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool PrimeSubOperation(int[] nums)
        {
            if (nums.Length == 1) return true;

            int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            List<int> primes = GetPrimes(max);

            for (int i = len - 2, cnt = primes.Count; i >= 0; i--) if (nums[i] >= nums[i + 1])
                {
                    for (int j = 0; j < cnt && primes[j] < nums[i]; j++) if (nums[i] - primes[j] < nums[i + 1])
                        {
                            nums[i] -= primes[j];
                            goto CONTINUE;
                        }
                    return false;
                CONTINUE:;
                }

            return true;

            static List<int> GetPrimes(int n)
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
}
