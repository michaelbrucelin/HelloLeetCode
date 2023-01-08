using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0088
{
    public class Solution0088 : Interface0088
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] result = new int[m + n];
            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
            {
                if (nums1[i] <= nums2[j]) result[k++] = nums1[i++]; else result[k++] = nums2[j++];
            }
            while (i < m) result[k++] = nums1[i++];
            while (j < n) result[k++] = nums2[j++];

            for (k = 0; k < result.Length; k++) nums1[k] = result[k];
        }
    }
}
