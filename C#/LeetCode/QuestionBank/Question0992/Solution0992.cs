using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0992
{
    public class Solution0992 : Interface0992
    {
        /// <summary>
        /// 同向三指针
        /// 使用三指针p1, p2, p3，p1是起点，nums[p1..p2]有k个不同的值，nums[p1..p3]有k+1个不同的值
        ///     则以p1为起点的好数组有p3-p2个
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraysWithKDistinct(int[] nums, int k)
        {
            int result = 0, p1 = -1, p2 = 0, p3 = 0, cnt, len = nums.Length;
            Dictionary<int, int> map2 = new Dictionary<int, int>() { { nums[0], 1 } };
            Dictionary<int, int> map3 = new Dictionary<int, int>() { { nums[0], 1 } };
            while (++p1 < len)
            {
                while (p2 + 1 < len && map2.Count < k) if (map2.TryGetValue(nums[++p2], out cnt)) map2[nums[p2]] = cnt + 1; else map2.Add(nums[p2], 1);
                while (p3 + 1 < len && map3.Count <= k) if (map3.TryGetValue(nums[++p3], out cnt)) map3[nums[p3]] = cnt + 1; else map3.Add(nums[p3], 1);
                if (map2.Count < k) break;
                if (map3.Count == k + 1) result += p3 - p2; else result += len - p2;
                if (map2[nums[p1]] == 1) map2.Remove(nums[p1]); else map2[nums[p1]]--;
                if (map3[nums[p1]] == 1) map3.Remove(nums[p1]); else map3[nums[p1]]--;
            }

            return result;
        }
    }
}
