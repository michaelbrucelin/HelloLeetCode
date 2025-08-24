using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1493
{
    public class Solution1493 : Interface1493
    {
        /// <summary>
        /// 贪心
        /// 1. 压缩信息，将原数组整理为 [几个1, 几个0, 几个1, ...]的形式
        ///     并记录下最长数量的1
        ///     如果没有0，数组长度减1便是结果
        /// 2. 遍历0的信息，如果是一个0，则将两边的1连起来与原结果比较
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestSubarray(int[] nums)
        {
            int len = nums.Length;
            List<int> dist = new List<int>();
            if (nums[0] == 0) dist.Add(0);             // 约定dist中0,2,4...记录的1的数量，1,3,5...记录的是0的数量
            int cnt = 1;
            for (int i = 1; i < len; i++)
            {
                if (nums[i] != nums[i - 1]) { dist.Add(cnt); cnt = 1; } else cnt++;
            }
            if ((dist.Count & 1) == 0) dist.Add(cnt);  // 如果最后一项是0的数量，不需要记录，后面的遍历也就不需要考虑越界的问题

            cnt = dist.Count;
            if (dist[0] == len) return len - 1;

            int result = 0;
            for (int i = 0; i < cnt; i += 2) result = Math.Max(result, dist[i]);
            for (int i = 1; i < cnt; i += 2) if (dist[i] == 1) result = Math.Max(result, dist[i - 1] + dist[i + 1]);

            return result;
        }
    }
}
