using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0137
{
    public class Solution0137_2_2 : Interface0137
    {
        public int SingleNumber(int[] nums)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (buffer.ContainsKey(nums[i]))
                {
                    if (buffer[nums[i]] == 1) buffer.Remove(nums[i]); else buffer[nums[i]] = 1;
                }
                else
                {
                    buffer.Add(nums[i], 2);
                }
            }

            if (buffer.Count == 1) return buffer.First().Key;

            throw new Exception("there is no answer.");
        }
    }
}
