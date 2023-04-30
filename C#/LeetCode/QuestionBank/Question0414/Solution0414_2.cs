using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0414
{
    public class Solution0414_2 : Interface0414
    {
        public int ThirdMax(int[] nums)
        {
            SortedSet<int> set = new SortedSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
                if (set.Count > 3) set.Remove(set.Min);
            }

            return set.Count == 3 ? set.Min : set.Max;
        }
    }
}
