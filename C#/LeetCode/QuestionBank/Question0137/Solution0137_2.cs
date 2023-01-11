using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0137
{
    public class Solution0137_2 : Interface0137
    {
        public int SingleNumber(int[] nums)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (buffer.ContainsKey(nums[i])) buffer[nums[i]]++; else buffer.Add(nums[i], 1);

            foreach (var kv in buffer) if (kv.Value == 1) return kv.Key;

            throw new Exception("there is no answer.");
        }

        public int SingleNumber2(int[] nums)
        {
            return nums.GroupBy(i => i)
                            .Select(group => new { i = group.Key, cnt = group.Count() })
                            .Where(group => group.cnt == 1)
                            .Select(i => i.i)
                            .First();
        }
    }
}
