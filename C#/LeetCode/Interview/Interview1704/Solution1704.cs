using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1704
{
    public class Solution1704 : Interface1704
    {
        public int MissingNumber(int[] nums)
        {
            int result = 0, n = nums.Length;
            for (int i = 0; i <= n; i++) result ^= i;
            for (int i = 0; i < n; i++) result ^= nums[i];

            return result;
        }

        public int MissingNumber2(int[] nums)
        {
            int result = nums.Length, n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                result ^= i; result ^= nums[i];
            }

            return result;
        }

        public int MissingNumber3(int[] nums)
        {
            HashSet<int> set = Enumerable.Range(0, nums.Length + 1).ToHashSet();
            for (int i = 0; i < nums.Length; i++) set.Remove(nums[i]);

            return set.First();
        }
    }
}
