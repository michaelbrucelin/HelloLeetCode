using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2780
{
    public class Solution2780 : Interface2780
    {
        /// <summary>
        /// 遍历
        /// 题目保证数组一定包含一个支配元素，这里假定是x，则如果拆分为两个子数组，至少有一个子数组的存在支配元素且支配元素是x
        /// 所以题目要求拆分为两个子数组且同时包含支配元素且都是x
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumIndex(IList<int> nums)
        {
            int target = 0, len = nums.Count, half = nums.Count >> 1;
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums) if (freq.TryGetValue(num, out int cnt)) freq[num] = ++cnt; else freq.Add(num, 1);
            foreach (int num in freq.Keys) if (freq[num] > half) target = num;  // 题目限定一定存在支配元素

            int lcnt = 0, rcnt = freq[target], llen = 1, rlen = len - 1;
            for (int i = 0; i < len; i++, llen++, rlen--)
            {
                if (nums[i] == target) { lcnt++; rcnt--; }
                if (lcnt > (llen >> 1) && rcnt > (rlen >> 1)) return i;
            }

            return -1;
        }

        /// <summary>
        /// 逻辑完全同MinimumIndex()，通过摩尔投票的方法找出数组的支配元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumIndex2(IList<int> nums)
        {
            int target = nums[0], cnt = 1, len = nums.Count, half = nums.Count >> 1;
            for (int i = 1; i < len; i++)
            {
                if (nums[i] == target)
                {
                    cnt++;
                }
                else
                {
                    if (cnt == 0) { target = nums[i]; cnt = 1; } else cnt--;
                }
            }
            cnt = 0;
            for (int i = 0; i < len; i++) if (nums[i] == target) cnt++;

            int lcnt = 0, rcnt = cnt, llen = 1, rlen = len - 1;
            for (int i = 0; i < len; i++, llen++, rlen--)
            {
                if (nums[i] == target) { lcnt++; rcnt--; }
                if (lcnt > (llen >> 1) && rcnt > (rlen >> 1)) return i;
            }

            return -1;
        }
    }
}
