using LeetCode.QuestionBank.Question0895;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1313
{
    public class Solution1313 : Interface1313
    {
        public int[] DecompressRLElist(int[] nums)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i += 2) for (int j = 0, v = nums[i + 1]; j < nums[i]; j++)
                {
                    result.Add(v);
                }

            return result.ToArray();
        }

        public int[] DecompressRLElist2(int[] nums)
        {
            int[] result = new int[nums.Where((i, id) => (id & 1) != 1).Sum()];
            for (int i = 0, id = 0; i < nums.Length; i += 2) for (int j = 0, v = nums[i + 1]; j < nums[i]; j++)
                {
                    result[id++] = v;
                }

            return result;
        }

        public int[] DecompressRLElist3(int[] nums)
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
