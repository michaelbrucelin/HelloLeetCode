using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3755
{
    public class Solution3755 : Interface3755
    {
        /// <summary>
        /// 前缀和
        /// xor可以通过前缀和的思路O(1)计算任意区间的xor值
        /// 奇偶数量相等可以将计数映射为1，偶数映射为-1，这样通过前缀和就可以O(1)的计算奇偶数量差
        /// 记录(xor,diff)对应的索引，当再次出现相同的(xor,diff)就是一个满足条件的子数组，diff是奇偶数量的前缀和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxBalancedSubarray(int[] nums)
        {
            int result = 0, xor = 0, diff = 0, len = nums.Length;
            Dictionary<(int, int), int> map = new Dictionary<(int, int), int>() { { (0, 0), -1 } };
            Func<int, int> func = (int x) => ((x & 1) << 1) - 1;
            for (int i = 0; i < len; i++)
            {
                xor ^= nums[i];
                diff += func(nums[i]);
                if (map.TryGetValue((xor, diff), out int idx)) result = Math.Max(result, i - idx); else map.Add((xor, diff), i);
            }

            return result;
        }
    }
}
