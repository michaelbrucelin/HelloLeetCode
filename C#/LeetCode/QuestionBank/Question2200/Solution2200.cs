using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2200
{
    public class Solution2200 : Interface2200
    {
        public IList<int> FindKDistantIndices(int[] nums, int key, int k)
        {
            List<int> result = new List<int>();
            List<int> points = new List<int>();
            for (int i = 0; i < nums.Length; i++) if (nums[i] == key) points.Add(i);

            int left = 0, right = nums.Length - 1;
            for (int i = 0; i < points.Count; i++)
            {
                left = Math.Max(left, points[i] - k); right = Math.Min(right, points[i] + k);
                for (int j = left; j <= right; j++) result.Add(j);
                left = right + 1; right = nums.Length - 1;
                if (left > right) break;
            }

            return result;
        }
    }
}
