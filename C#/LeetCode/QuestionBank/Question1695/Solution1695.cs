using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1695
{
    public class Solution1695 : Interface1695
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumUniqueSubarray(int[] nums)
        {
            int result = 0, len = nums.Length;
            HashSet<int> set = new HashSet<int>();
            int pl = 0, pr = -1, window = 0;
            while (pr < len)
            {
                while (pr + 1 < len && !set.Contains(nums[pr + 1]))
                {
                    window += nums[pr + 1]; set.Add(nums[pr + 1]); pr++;
                }
                result = Math.Max(result, window);
                if (pr == len - 1) break;
                while (nums[pl] != nums[pr + 1])
                {
                    window -= nums[pl]; set.Remove(nums[pl]); pl++;
                }
                window -= nums[pl]; set.Remove(nums[pl]); pl++;
            }

            return result;
        }

        /// <summary>
        /// 逻辑与MaximumUniqueSubarray()完全相同，只是将集合改为数组
        /// 
        /// 数组的确比Hash快
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumUniqueSubarray2(int[] nums)
        {
            int result = 0, len = nums.Length;
            bool[] set = new bool[10001];
            int pl = 0, pr = -1, window = 0;
            while (pr < len)
            {
                while (pr + 1 < len && !set[nums[pr + 1]])
                {
                    window += nums[pr + 1]; set[nums[pr + 1]] = true; pr++;
                }
                result = Math.Max(result, window);
                if (pr == len - 1) break;
                while (nums[pl] != nums[pr + 1])
                {
                    window -= nums[pl]; set[nums[pl]] = false; pl++;
                }
                window -= nums[pl]; set[nums[pl]] = false; pl++;
            }

            return result;
        }
    }
}
