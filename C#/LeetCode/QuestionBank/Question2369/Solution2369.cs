using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2369
{
    public class Solution2369 : Interface2369
    {
        /// <summary>
        /// DFS
        /// 逻辑没有问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ValidPartition(int[] nums)
        {
            return ValidPartition(nums, 0);
        }

        private bool ValidPartition(int[] nums, int start)
        {
            int len = nums.Length;
            if (len - start == 0) return true; else if (len - start == 1) return false;

            if (nums[start] == nums[start + 1])
            {
                if (ValidPartition(nums, start + 2)) return true;
                if (start + 2 < len && nums[start] == nums[start + 2])
                {
                    if (ValidPartition(nums, start + 3)) return true;
                }
            }

            if (start + 2 < len && nums[start] + 1 == nums[start + 1] && nums[start] + 2 == nums[start + 2])
            {
                if (ValidPartition(nums, start + 3)) return true;
            }

            return false;
        }
    }
}
