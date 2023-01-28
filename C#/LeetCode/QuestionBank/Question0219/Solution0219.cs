using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0219
{
    public class Solution0219 : Interface0219
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (k == 0 || nums.Length == 1) return false;

            int len = nums.Length, border;
            for (int i = 0; i < len; i++)
            {
                border = Math.Min(len - 1, i + k);
                for (int j = i + 1; j <= border; j++) if (nums[i] == nums[j]) return true;
            }

            return false;
        }
    }
}
