using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2799
{
    public class Solution2799 : Interface2799
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountCompleteSubarrays(int[] nums)
        {
            int total = 0, len = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in nums) map.TryAdd(num, 0);
            total = map.Count;

            int result = 0, cnt = 0, pl = 0, pr = -1;
            while (pr < len)
            {
                while (cnt < total && ++pr < len) if (++map[nums[pr]] == 1) cnt++;
                if (cnt < total) break;
                while (cnt == total)
                {
                    result += len - pr;
                    if (--map[nums[pl++]] == 0) cnt--;
                }
            }

            return result;
        }
    }
}
