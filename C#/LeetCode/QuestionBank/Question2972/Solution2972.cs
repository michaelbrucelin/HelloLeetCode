using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2972
{
    public class Solution2972 : Interface2972
    {
        /// <summary>
        /// 双指针，排列组合
        /// 思路，移除一个子数组后，余下“前缀数组”和“后缀数组”
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long IncremovableSubarrayCount(int[] nums)
        {
            if (nums.Length == 1) return 1;

            int bl = 0, br = nums.Length - 1, len = nums.Length;
            while (bl < br && nums[bl] < nums[bl + 1]) bl++;      // 前缀数组
            if (bl == br) return len * (len + 1) >> 1;
            while (nums[br] > nums[br - 1]) br--;                 // 后缀数组

            long result = len - br + 1;                           // 前缀数组全部删除
            int pl = -1, pr = br;
            while (++pl <= bl)
            {
                while (pr < len && nums[pr] <= nums[pl]) pr++;
                result += len - pr + 1;
            }

            return result;
        }
    }
}
