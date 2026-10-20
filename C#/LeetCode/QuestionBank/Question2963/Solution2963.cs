
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2963
{
    public class Solution2963 : Interface2963
    {
        /// <summary>
        /// 组合数学
        /// 先将数组分组，相同的元素一定被分为1组，分为n组的话，结果为2^n
        /// 将数组分组的过程就是合并区间的过程
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumberOfGoodPartitions(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int len = nums.Length;
            Dictionary<int, (int, int)> map = new Dictionary<int, (int, int)>();
            for (int i = 0; i < len; i++)
            {
                if (map.TryGetValue(nums[i], out var t)) map[nums[i]] = (Math.Min(t.Item1, i), Math.Max(t.Item2, i)); else map.Add(nums[i], (i, i));
            }
            (int, int)[] ranges = new (int, int)[map.Count];
            int id = 0;
            foreach (var val in map.Values) ranges[id++] = val;
            Array.Sort(ranges, (x, y) => x.Item1 - y.Item1);

            int cnt = 0, border = -1;
            foreach ((int left, int right) in ranges)
            {
                if (left > border) { cnt++; border = right; } else { border = Math.Max(border, right); }
            }

            int result = 1;
            while (--cnt > 0) result = (result << 1) % MOD;  // 这里可以使用快速幂加速，这里就不写了
            return result;
        }
    }
}
