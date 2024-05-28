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
            var query1 = nums1.Select((num, id) => (num, id));
            var query2 = nums2.Select((num, id) => (num, id));
            return query1.SelectMany(t1 => query2.Select(t2 => (t1, t2))).Count(t => t.t1.num % (t.t2.num * k) == 0);
        }
    }
}
