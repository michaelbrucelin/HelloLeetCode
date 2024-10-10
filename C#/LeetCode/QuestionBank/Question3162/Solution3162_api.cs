using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3162
{
    public class Solution3162_api : Interface3162
    {
        public int NumberOfPairs(int[] nums1, int[] nums2, int k)
        {
            return nums1.SelectMany(x => nums2.Select(y => (x, y))).Count(t => t.x % (t.y * k) == 0);
        }
    }
}
