using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0028
{
    public class Solution0028 : Interface0028
    {
        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int PurchasePlans(int[] nums, int target)
        {
            Array.Sort(nums);
            const int MOD = (int)1e9 + 7;
            int result = 0, pl = 0, pr = nums.Length - 1;
            while (pl < pr)
            {
                while (pl < pr && nums[pl] + nums[pr] > target) pr--;
                if (pl < pr) result = (result + pr - pl) % MOD;
                pl++;
            }

            return result;
        }
    }
}
