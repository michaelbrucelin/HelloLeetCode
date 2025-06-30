using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0594
{
    public class Solution0594 : Interface0594
    {
        /// <summary>
        /// 分析
        /// 统计每个元素的数量，找出相邻元素对中数目最多的那对
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLHS(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in nums) if (map.ContainsKey(num)) map[num]++; else map.Add(num, 1);

            int result = 0;
            foreach (var key in map.Keys) if (map.ContainsKey(key - 1))
                {
                    result = Math.Max(result, map[key] + map[key - 1]);
                }

            return result;
        }
    }
}
