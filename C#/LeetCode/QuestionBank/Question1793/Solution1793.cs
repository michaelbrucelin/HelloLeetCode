using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1793
{
    public class Solution1793 : Interface1793
    {
        /// <summary>
        /// 双指针
        /// 1. 构造int[] mins，记录nums中从k向两边的最小值
        ///     idx:   0  1  2  3  4  5
        ///     nums: {1, 4, 3, 7, 4, 5}, k = 3
        ///     mins: {1, 3, 3, 7, 4, 4}
        /// 2. 双指针（pl, pr）指向mins的两端，向k的位置逼近
        ///     由于向中间逼近，元素的数量减少了，要想乘积变大，最小值必须变大，所以
        ///     mins[pl] < mins[pr], pl向k逼近
        ///     mins[pl] > mins[pr], pr向k逼近
        ///     mins[pl] = mins[pr], pl与pr同时向k逼近
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumScore(int[] nums, int k)
        {
            int len = nums.Length;
            int[] mins = new int[len]; mins[k] = nums[k];
            for (int i = k - 1; i >= 0; i--) mins[i] = Math.Min(nums[i], mins[i + 1]);
            for (int i = k + 1; i < len; i++) mins[i] = Math.Min(nums[i], mins[i - 1]);

            int result = nums[k], _result, pl = 0, pr = len - 1;
            while (pl < pr)
            {
                _result = Math.Min(mins[pl], mins[pr]) * (pr - pl + 1);
                result = Math.Max(result, _result);
                switch (mins[pl] - mins[pr])
                {
                    case > 0:
                        while (mins[pr - 1] == mins[pr]) pr--; pr--; break;
                    case < 0:
                        while (mins[pl + 1] == mins[pl]) pl++; pl++; break;
                    default:  // == 0
                        if (mins[pl] == mins[k])
                        {
                            pl = pr;
                        }
                        else
                        {
                            while (mins[pr - 1] == mins[pr]) pr--; pr--;
                            while (mins[pl + 1] == mins[pl]) pl++; pl++;
                        }
                        break;
                }
            }

            return result;
        }
    }
}
