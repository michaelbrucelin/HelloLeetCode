using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1313
{
    public class Solution1313_api : Interface1313
    {
        public int[] DecompressRLElist(int[] nums)
        {
            return nums.Skip(1)
                       .Select((value, id) => (nums[id], value))
                       .Where((item, id) => (id & 1) != 1)
                       .Select(item => Enumerable.Repeat(item.value, item.Item1))
                       .SelectMany(nums => nums)
                       .ToArray();
        }
    }
}
