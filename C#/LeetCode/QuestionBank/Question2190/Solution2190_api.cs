using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2190
{
    public class Solution2190_api : Interface2190
    {
        public int MostFrequent(int[] nums, int key)
        {
            return nums.Take(nums.Length - 1)
                       .Select((num, id) => (num, id))
                       .Where(t => t.num == key)
                       .Select(t => nums[t.id + 1])
                       .GroupBy(i => i)
                       .OrderByDescending(g => g.Count())
                       .First().Key;
        }
    }
}
