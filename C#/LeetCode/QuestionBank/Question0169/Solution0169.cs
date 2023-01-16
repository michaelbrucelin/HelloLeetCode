using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0169
{
    public class Solution0169 : Interface0169
    {
        public int MajorityElement(int[] nums)
        {
            int floor = nums.Length / 2;
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (buffer.ContainsKey(val)) buffer[val]++; else buffer.Add(val, 1);

                if (buffer[val] > floor) return val;
            }

            throw new Exception("there is no result.");
        }

        public int MajorityElement2(int[] nums)
        {
            return nums.GroupBy(i => i).Select(g => new { item = g.Key, cnt = g.Count() }).OrderByDescending(i => i.cnt).First().item;
        }
    }
}
