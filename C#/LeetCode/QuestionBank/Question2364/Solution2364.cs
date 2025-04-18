using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2364
{
    public class Solution2364 : Interface2364
    {
        /// <summary>
        /// 逆向思维，排列组合
        /// 统计好的数对的数量，然后用总的数对的数量减去好的数对数量即可。
        /// j - i = nums[j] - nums[i] => j - nums[j] = i - nums[i]
        /// 所以遍历整个数组安装nums[i]-i分组即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long CountBadPairs(int[] nums)
        {
            int len = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0, key; i < len; i++)
            {
                key = nums[i] - i;
                map.TryAdd(key, 0);
                map[key]++;
            }

            long result = ((long)len) * (len - 1) >> 1;
            foreach (long cnt in map.Values) result -= (cnt * (cnt - 1)) >> 1;

            return result;
        }
    }
}
