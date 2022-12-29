using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2032
{
    public class Solution2032_2 : Interface2032
    {
        public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
                if (buffer.ContainsKey(nums1[i])) buffer[nums1[i]] |= 1; else buffer.Add(nums1[i], 1);
            for (int i = 0; i < nums2.Length; i++)
                if (buffer.ContainsKey(nums2[i])) buffer[nums2[i]] |= 2; else buffer.Add(nums2[i], 2);
            for (int i = 0; i < nums3.Length; i++)
                if (buffer.ContainsKey(nums3[i])) buffer[nums3[i]] |= 4; else buffer.Add(nums3[i], 4);

            List<int> result = new List<int>();
            foreach (var kv in buffer)
            {
                int key = kv.Key, value = kv.Value;
                if ((value & (value - 1)) != 0) result.Add(key);
            }

            return result;
        }
    }
}
