using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2537
{
    public class Solution2537 : Interface2537
    {
        /// <summary>
        /// 双指针，滑动窗口
        /// 使用前后两个指针维护一个窗口，并维护窗口内每个元素的频次与当前总的“相等的元素对”的数量
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountGood(int[] nums, int k)
        {
            long result = 0, len = nums.Length;
            Dictionary<int, int> window = new Dictionary<int, int>();
            int pl = 0, pr = -1, cnt = 0;
            while (pl < len || pr < len)
            {
                while (++pr < len)  // (pr < len && cnt < k)
                {
                    if (window.ContainsKey(nums[pr]))
                    {
                        cnt += window[nums[pr]];
                        window[nums[pr]]++;
                        if (cnt >= k) break;
                    }
                    else
                    {
                        window.Add(nums[pr], 1);
                    }
                }

                if (cnt >= k)
                {
                    while (cnt >= k)
                    {
                        result += len - pr;
                        cnt -= window[nums[pl]] - 1;
                        if (--window[nums[pl]] == 0) window.Remove(nums[pl]);
                        pl++;
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
