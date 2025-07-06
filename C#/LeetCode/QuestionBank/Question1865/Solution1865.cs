using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1865
{
    public class Solution1865
    {
    }

    /// <summary>
    /// Hash
    /// </summary>
    public class FindSumPairs : Interface1865
    {
        public FindSumPairs(int[] nums1, int[] nums2)
        {
            this.nums2 = nums2;
            map1 = new Dictionary<int, int>();
            foreach (int num in nums1) if (map1.ContainsKey(num)) map1[num]++; else map1.Add(num, 1);
            map2 = new Dictionary<int, int>();
            foreach (int num in nums2) if (map2.ContainsKey(num)) map2[num]++; else map2.Add(num, 1);
        }

        private Dictionary<int, int> map1;
        private Dictionary<int, int> map2;
        private int[] nums2;

        public void Add(int index, int val)
        {
            int num = nums2[index];
            map2[num]--;
            num += val;
            if (map2.ContainsKey(num)) map2[num]++; else map2.Add(num, 1);
            nums2[index] = num;
        }

        public int Count(int tot)
        {
            int count = 0;
            foreach (int num in map1.Keys) if (map2.ContainsKey(tot - num)) count += map1[num] * map2[tot - num];
            return count;
        }
    }
}
