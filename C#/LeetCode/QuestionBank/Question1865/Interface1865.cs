using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1865
{
    /// <summary>
    /// Your FindSumPairs object will be instantiated and called as such:
    /// FindSumPairs obj = new FindSumPairs(nums1, nums2);
    /// obj.Add(index, val);
    /// int param_2 = obj.Count(tot);
    /// </summary>
    public interface Interface1865
    {
        // public FindSumPairs(int[] nums1, int[] nums2)
        // {
        // }

        public void Add(int index, int val);

        public int Count(int tot);
    }
}
