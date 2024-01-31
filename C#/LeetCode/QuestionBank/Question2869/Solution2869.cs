using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2869
{
    public class Solution2869 : Interface2869
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations(IList<int> nums, int k)
        {
            int result = 0;
            HashSet<int> set = new HashSet<int>();
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                result++;
                if (nums[i] <= k)
                {
                    set.Add(nums[i]);
                    if (set.Count == k) break;
                }
            }

            return result;
        }

        /// <summary>
        /// 逻辑同MinOperations()，只是将哈希表改为了long
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations2(IList<int> nums, int k)
        {
            int result = 0;
            long mask = 0, MASK = (1L << k) - 1;
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                result++;
                if (nums[i] <= k)
                {
                    mask |= 1L << (nums[i] - 1);
                    if (mask == MASK) break;
                }
            }

            return result;
        }
    }
}
