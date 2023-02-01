using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2248
{
    public class Solution2248 : Interface2248
    {
        public IList<int> Intersection(int[][] nums)
        {
            HashSet<int> result = new HashSet<int>(nums[0]);
            HashSet<int> next, buffer = new HashSet<int>(), t;
            for (int i = 1; i < nums.Length; i++)
            {
                buffer.Clear();
                next = new HashSet<int>(nums[i]);
                foreach (int val in result) if (next.Contains(val)) buffer.Add(val);
                t = result; result = buffer; buffer = t;
            }

            return result.OrderBy(i => i).ToList();
        }

        public IList<int> Intersection2(int[][] nums)
        {
            HashSet<int> result = new HashSet<int>(nums[0]);
            for (int i = 1; i < nums.Length; i++) result.IntersectWith(nums[i]);

            return result.OrderBy(i => i).ToList();
        }

        public IList<int> Intersection3(int[][] nums)
        {
            return nums.Aggregate((arr1, arr2) => arr1.Intersect(arr2).ToArray()).OrderBy(i => i).ToList();
        }
    }
}
