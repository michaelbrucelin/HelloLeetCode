using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0088
{
    public class Solution0088_5 : Interface0088
    {
        /// <summary>
        /// 从后向前遍历
        /// 简单证明从后向前遍历，不会发生元素覆盖的情况
        /// 1. nums1向后移动元素，空位数量不变
        /// 2. nums2向nums1后面添加元素，添加几个，空位少几个
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int ptr1 = m - 1, ptr2 = n - 1, ptr = m + n - 1;
            while (ptr1 >= 0 && ptr2 >= 0)
            {
                if (nums1[ptr1] >= nums2[ptr2]) nums1[ptr--] = nums1[ptr1--]; else nums1[ptr--] = nums2[ptr2--];
            }
            while (ptr1 >= 0) nums1[ptr--] = nums1[ptr1--];
            while (ptr2 >= 0) nums1[ptr--] = nums2[ptr2--];
        }
    }
}
