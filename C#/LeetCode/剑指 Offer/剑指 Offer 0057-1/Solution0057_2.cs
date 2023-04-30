using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0057_1
{
    public class Solution0057_2 : Interface0057
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            if ((target & 1) != 1)
            {
                Dictionary<int, int> hash = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    hash.TryAdd(nums[i], 0); hash[nums[i]]++;
                }
                for (int i = 0, target2 = target >> 1; i < nums.Length; i++)
                {
                    if (nums[i] == target2 && hash[nums[i]] >= 2)
                        return new int[] { nums[i], nums[i] };
                    else if (hash.ContainsKey(target - nums[i]))
                        return new int[] { nums[i], target - nums[i] };
                }
            }
            else
            {
                HashSet<int> hash = new HashSet<int>();
                for (int i = 0; i < nums.Length; i++) hash.Add(nums[i]);
                for (int i = 0; i < nums.Length; i++)
                    if (hash.Contains(target - nums[i])) return new[] { nums[i], target - nums[i] };
            }

            return null;
        }
    }
}
