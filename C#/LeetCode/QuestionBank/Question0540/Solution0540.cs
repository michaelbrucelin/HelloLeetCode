using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0540
{
    public class Solution0540 : Interface0540
    {
        /// <summary>
        /// 二分法
        /// 偶数坐标应该与后面的元素相同，奇数坐标应该与前面的元素相同
        ///     相同，问题在后面
        ///     不同，问题在前面
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNonDuplicate(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            return BinarySearch(0, nums.Length - 1);

            int BinarySearch(int l, int r)
            {
                int m = l + ((r - l) >> 1);
                if ((m == 0 && nums[m] != nums[m + 1]) || (m == nums.Length - 1 && nums[m] != nums[m - 1]) || (nums[m] != nums[m - 1] && nums[m] != nums[m + 1])) return nums[m];
                if ((m & 1) == 0)
                {
                    if (nums[m] == nums[m + 1]) l = m + 1; else r = m - 1;
                    return BinarySearch(l, r);
                }
                else
                {
                    if (nums[m] == nums[m - 1]) l = m + 1; else r = m - 1;
                    return BinarySearch(l, r);
                }
            }
        }
    }
}
