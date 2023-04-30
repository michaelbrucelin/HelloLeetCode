using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0039
{
    public class Solution0039_api : Interface0039
    {
        public int MajorityElement(int[] nums)
        {
            return nums.GroupBy(i => i).OrderByDescending(g => g.Count()).First().Key;
        }

        public int MajorityElement2(int[] nums)
        {
            return nums.OrderBy(i => i).Skip(nums.Length >> 1).First();
        }
    }
}
