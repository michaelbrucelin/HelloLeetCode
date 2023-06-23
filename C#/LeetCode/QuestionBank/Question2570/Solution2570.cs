using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2570
{
    public class Solution2570 : Interface2570
    {
        /// <summary>
        /// 归并
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            List<int[]> result = new List<int[]>();
            int i = 0, j = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i][0] < nums2[j][0])
                    result.Add(nums1[i++]);
                else if (nums1[i][0] > nums2[j][0])
                    result.Add(nums2[j++]);
                else
                    result.Add(new int[] { nums1[i][0], nums1[i++][1] + nums2[j++][1] });
            }
            while (i < nums1.Length) result.Add(nums1[i++]);
            while (j < nums2.Length) result.Add(nums2[j++]);

            return result.ToArray();
        }
    }
}
