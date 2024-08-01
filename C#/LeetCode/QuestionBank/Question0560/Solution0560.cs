using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0560
{
    public class Solution0560 : Interface0560
    {
        /// <summary>
        /// 前缀和逆映射为字典
        /// 1. 计算前缀和（sums）并将其转为字典（map），key为“和”，值为该“和”的数量
        /// 2. result += map[key]
        /// 3. map[sums[0]]--; result += map[key+sums[0]]
        /// 4. map[sums[1]]--; result += map[key+sums[1]]
        /// ... ...
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums, int k)
        {
            int len = nums.Length;
            int[] sums = new int[len]; sums[0] = nums[0];
            for (int i = 1; i < len; i++) sums[i] += sums[i - 1] + nums[i];
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int sum in sums) if (map.ContainsKey(sum)) map[sum]++; else map.Add(sum, 1);

            int result = map.ContainsKey(k) ? map[k] : 0;
            for (int i = 0; i < len - 1; i++)
            {
                map[sums[i]]--;
                result += map.ContainsKey(k + sums[i]) ? map[k + sums[i]] : 0;
            }

            return result;
        }
    }
}
