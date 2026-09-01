using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3909
{
    public class Solution3909 : Interface3909
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CompareBitonicSums(int[] nums)
        {
            long suml = nums[0], sumr = 0;
            int id = 0, len = nums.Length;
            while (++id < len && nums[id] > nums[id - 1]) suml += nums[id];
            sumr += nums[id - 1];
            while (id < len) sumr += nums[id++];

            return (suml - sumr) switch { > 0 => 0, < 0 => 1, _ => -1 };
        }
    }
}
