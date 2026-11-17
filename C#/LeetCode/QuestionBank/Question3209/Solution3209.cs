using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3209
{
    public class Solution3209 : Interface3209
    {
        /// <summary>
        /// LogTrick
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, int k)
        {
            long result = 0; int len = nums.Length;
            int[] ands = new int[len], cnts = new int[len];
            for (int i = 0, and; i < len; i++)
            {
                ands[i] = nums[i];
                if (nums[i] == k) { result++; cnts[i]++; }
                for (int j = i - 1; j >= 0; j--)
                {
                    and = ands[j] & nums[i];
                    if (and == k || and == ands[j])
                    {
                        result += cnts[j]; cnts[i] += cnts[j]; ands[j] = and;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
