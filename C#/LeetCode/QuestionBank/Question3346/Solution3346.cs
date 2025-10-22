using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3346
{
    public class Solution3346 : Interface3346
    {
        /// <summary>
        /// 排序 + 两轮滑动窗口
        /// 1. 排序
        /// 2. 第1轮滑动窗口
        ///     pl为左指针，pr为满足nums[pr]-nums[pl]<=2k最大的右指针
        ///     那么以pl为起点的最大频次为Min(pr-pl+1, numOperations)
        /// 3. 第2轮滑动窗口，贡献值
        ///     遍历nums中每个元素num
        ///     pl为满足num-nums[pl]<=k的最小左指针，pr为满足nums[pr]-num<=k最大的右指针
        ///     那么以num为目标贡献的最大频次为Min(pr-pl+1-Count(num), numOperations)+Count(num)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="numOperations"></param>
        /// <returns></returns>
        public int MaxFrequency(int[] nums, int k, int numOperations)
        {
            // if(k == 0 || numOperations == 0) ...

            Array.Sort(nums);
            int result = 0, len = nums.Length;

            // 第1轮滑动窗口
            int pl = -1, pr = 0, k2 = k << 1;
            while (++pl < len)
            {
                while (pr + 1 < len && nums[pr + 1] - nums[pl] <= k2) pr++;
                result = Math.Max(result, Math.Min(pr - pl + 1, numOperations));
                if (pr == len - 1) break;
            }
            // 第2轮滑动窗口
            int p = 0, _p; pl = 0; pr = 0;
            while (p < len)
            {
                _p = p;
                while (_p + 1 < len && nums[_p + 1] == nums[_p]) _p++;
                while (nums[p] - nums[pl] > k) pl++;
                while (pr + 1 < len && nums[pr + 1] - nums[p] <= k) pr++;
                result = Math.Max(result, Math.Min((pr - pl) - (_p - p), numOperations) + _p - p + 1);
                p = _p + 1;
            }

            return result;
        }
    }
}
