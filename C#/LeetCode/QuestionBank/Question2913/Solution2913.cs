using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2913
{
    public class Solution2913 : Interface2913
    {
        /// <summary>
        /// 暴力枚举
        /// 类似于滑动窗口的方式的暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumCounts(IList<int> nums)
        {
            const int MOD = 1000000007;
            long result = 0, cnt = nums.Count;
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int width = 1; width <= cnt; width++)
            {
                freq.Clear();
                for (int i = 0; i < width; i++)
                    if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);
                result += freq.Count * freq.Count; result %= MOD;

                for (int i = width; i < cnt; i++)
                {
                    if (nums[i] != nums[i - width])
                    {
                        if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);
                        freq[nums[i - width]]--; if (freq[nums[i - width]] == 0) freq.Remove(nums[i - width]);
                    }
                    result += freq.Count * freq.Count; result %= MOD;
                }
            }

            return (int)result;
        }

        /// <summary>
        /// 暴力枚举
        /// 依然是暴力枚举，换了一种枚举的方式，每一次都枚举完以某个元素为起点的全部子数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumCounts2(IList<int> nums)
        {
            const int MOD = 1000000007;
            long result = 0, cnt = nums.Count;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < cnt; i++)
            {
                set.Clear();
                for (int j = i; j < cnt; j++)
                {
                    set.Add(nums[j]);
                    result += set.Count * set.Count; result %= MOD;
                }
            }

            return (int)result;
        }
    }
}
