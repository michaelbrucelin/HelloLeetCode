using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2958
{
    public class Solution2958 : Interface2958
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSubarrayLength(int[] nums, int k)
        {
            int result = 0, p1 = 0, p2 = -1, len = nums.Length;
            Dictionary<int, int> freq = new Dictionary<int, int>();
            while (len - p1 > result)
            {
                while (p2 + 1 < len)
                {
                    if (freq.TryGetValue(nums[p2 + 1], out int cnt))
                    {
                        if (cnt < k) freq[nums[++p2]]++; else break;
                    }
                    else
                    {
                        freq.Add(nums[++p2], 1);
                    }
                }
                result = Math.Max(result, p2 - p1 + 1);
                if (p2 == len - 1) break;
                freq[nums[++p2]]++;
                while (nums[p1] != nums[p2]) if (freq[nums[p1]] != 1) freq[nums[p1++]]--; else freq.Remove(nums[p1++]);
                freq[nums[p1++]]--;
            }

            return result;
        }
    }
}
