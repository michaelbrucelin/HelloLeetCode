using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2488
{
    public class Solution2488_2 : Interface2488
    {
        public int CountSubarrays(int[] nums, int k)
        {
            int len = nums.Length;
            int kid; for (kid = 0; kid < len; kid++) if (nums[kid] == k) break;
            Dictionary<int, int> left = new Dictionary<int, int>() { { 0, 1 } };
            int result = 0;
            for (int i = 0, sum = 0; i < len; i++)
            {
                sum += Math.Sign(nums[i] - k);
                if (i < kid)
                {
                    left.TryAdd(sum, 0); left[sum]++;
                }
                else
                {
                    result += left.ContainsKey(sum) ? left[sum] : 0;
                    result += left.ContainsKey(sum - 1) ? left[sum - 1] : 0;
                }
            }

            return result;
        }
    }
}
