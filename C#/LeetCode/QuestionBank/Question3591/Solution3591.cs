using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3591
{
    public class Solution3591 : Interface3591
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CheckPrimeFrequency(int[] nums)
        {
            bool[] isprime = GetPrimes(101);
            int[] freq = new int[101];
            for (int i = 0, len = nums.Length; i < len; i++) freq[nums[i]]++;
            for (int i = 0; i < 101; i++) if (freq[i] != 0 && isprime[freq[i]]) return true;
            return false;

            static bool[] GetPrimes(int n)
            {
                List<int> result = new List<int>();
                bool[] mask = new bool[n]; Array.Fill(mask, true); mask[1] = false;
                for (int i = 2; i < n; i++)
                {
                    if (mask[i]) result.Add(i);
                    for (int j = 0; j < result.Count && i * result[j] < n; j++)
                    {
                        mask[i * result[j]] = false;
                        if (i % result[j] == 0) break;
                    }
                }

                return mask;
            }
        }
    }
}
