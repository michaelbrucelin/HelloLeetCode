using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3634
{
    public class Solution3634 : Interface3634
    {
        /// <summary>
        /// 排序 + 二分
        /// 先将数组排序，然后从两边移除元素即可，如果移除x个元素满足要求，显然移除y(y>x)个元素也满足要求，所以可以二分
        /// 怎样判断移除x个元素是否满足要求，一次尝试 左0右x，左1右x-1 ... ... 左x右0 即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinRemoval(int[] nums, int k)
        {
            Array.Sort(nums);
            int len = nums.Length;
            int result = len - 1, low = 0, high = len - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                for (int pl = 0, pr = len - 1 - mid; pr < len; pl++, pr++) if (1L * nums[pl] * k >= nums[pr])
                    {
                        result = mid; high = mid - 1; goto YES;
                    }
                low = mid + 1;
            YES:;
            }

            return result;
        }
    }
}
