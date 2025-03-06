using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2588
{
    public class Solution2588_2 : Interface2588
    {
        /// <summary>
        /// 类前缀和，枚举右维护左
        /// 逻辑同官解，本质上与Solution2588一样，也没多复杂，但是第一时间就是没想出来
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long BeautifulSubarrays(int[] nums)
        {
            long result = 0;
            int xor = 0, len = nums.Length;
            Dictionary<int, int> map = new() { { 0, 1 } };
            foreach (int num in nums)
            {
                xor ^= num;
                if (map.ContainsKey(xor)) result += map[xor]++; else map.Add(xor, 1);
            }

            return result;
        }
    }
}
