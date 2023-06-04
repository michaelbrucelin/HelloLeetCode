using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2465
{
    public class Solution2465 : Interface2465
    {
        public int DistinctAverages(int[] nums)
        {
            int len = nums.Length;
            Array.Sort(nums);
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < (len >> 1); i++) set.Add(nums[i] + nums[len - i - 1]);

            return set.Count;
        }
    }
}
