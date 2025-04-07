using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2248
{
    public class Solution2248_3 : Interface2248
    {
        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> Intersection(int[][] nums)
        {
            return [.. dc(0, nums.Length - 1).Order()];     // dc(0, nums.Length - 1).Order().ToList()

            HashSet<int> dc(int left, int right)
            {
                if (left == right) return [.. nums[left]];  // new HashSet<int>(nums[left])

                int mid = left + ((right - left) >> 1);
                HashSet<int> s1 = dc(left, mid);
                HashSet<int> s2 = dc(mid + 1, right);
                HashSet<int> result = new HashSet<int>();
                foreach (int num in s1) if (s2.Contains(num)) result.Add(num);

                return result;
            }
        }
    }
}
