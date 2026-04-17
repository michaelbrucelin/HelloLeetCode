using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3761
{
    public class Solution3761 : Interface3761
    {
        /// <summary>
        /// Hash
        /// 维护左，枚举右
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMirrorPairDistance(int[] nums)
        {
            int result = int.MaxValue, len = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0, num, key; i < len; i++)
            {
                num = nums[i];
                if (map.TryGetValue(num, out int idx))
                {
                    if (i - idx == 1) return 1;
                    result = Math.Min(result, i - idx);
                }

                key = 0;
                while (num > 0) { key = key * 10 + num % 10; num /= 10; }
                if (!map.TryAdd(key, i)) map[key] = i;
            }

            return result != int.MaxValue ? result : -1;
        }
    }
}
