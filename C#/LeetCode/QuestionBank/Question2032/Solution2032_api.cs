using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2032
{
    public class Solution2032_api : Interface2032
    {
        public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            HashSet<int> result = new HashSet<int>(nums1.Intersect(nums2));
            result.UnionWith(nums1.Intersect(nums3));
            result.UnionWith(nums2.Intersect(nums3));

            return result.ToList();
        }
    }
}
