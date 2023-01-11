using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0260
{
    public class Solution0260_2 : Interface0260
    {
        public int[] SingleNumber(int[] nums)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (buffer.ContainsKey(nums[i])) buffer[nums[i]]++; else buffer.Add(nums[i], 1);

            int[] result = new int[2]; int id = 0;
            foreach (var kv in buffer)
            {
                if (kv.Value == 1)
                {
                    result[id++] = kv.Key;
                    if (id == 2) break;
                }
            }

            return result;
        }

        /// <summary>
        /// 使用API
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SingleNumber2(int[] nums)
        {
            return nums.GroupBy(i => i)
                            .Select(group => new { i = group.Key, cnt = group.Count() })
                            .Where(group => group.cnt == 1)
                            .Select(group => group.i)
                            .ToArray();
        }
    }
}
