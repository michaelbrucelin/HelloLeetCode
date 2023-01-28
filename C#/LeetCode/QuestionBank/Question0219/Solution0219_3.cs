using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0219
{
    public class Solution0219_3 : Interface0219
    {
        /// <summary>
        /// 滑动窗口
        /// 使用滑动窗口可以将此问题转换为Question0217
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (k == 0 || nums.Length == 1) return false;

            HashSet<int> window = new HashSet<int>();
            int left = 0, right = Math.Min(nums.Length - 1, k);
            for (int i = left; i <= right; i++)
            {
                if (window.Contains(nums[i])) return true;
                window.Add(nums[i]);
            }

            while (++right < nums.Length)
            {
                window.Remove(nums[left++]);
                if (window.Contains(nums[right])) return true;
                window.Add(nums[right]);
            }

            return false;
        }
    }
}
