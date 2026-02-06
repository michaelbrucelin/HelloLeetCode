using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0083
{
    public class Solution0083_3 : Interface0083
    {
        /// <summary>
        /// 下一个更大的排列
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = [];
            Array.Sort(nums);
            result.Add([.. nums]);
            bool flag = true; int i, j, t, n = nums.Length;
            while (flag)
            {
                for (i = n - 2; i >= 0 && nums[i] >= nums[i + 1]; i--) ;
                if (i < 0) break;
                for (j = n - 1; j > 0 && nums[j] <= nums[i]; j--) ;
                t = nums[i]; nums[i] = nums[j]; nums[j] = t;
                for (int l = i + 1, r = n - 1; l < r; l++, r--)
                {
                    t = nums[l]; nums[l] = nums[r]; nums[r] = t;
                }
                result.Add([.. nums]);
            }

            return result;
        }
    }
}
