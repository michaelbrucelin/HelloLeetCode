using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0088
{
    public class Solution0088_2 : Interface0088
    {
        /// <summary>
        /// 双指针 + 队列
        /// 使用ptr1指向nums1，ptr2指向nums2，创建一个队列queue，然后比较nums1[ptr1], nums2[ptr2]与queue.Peek()这3个元素
        ///     如果nums1[ptr1]最小，那么ptr1++
        ///     如果nums2[ptr2]最小，那么将nums1[ptr1]放入队列，然后令nums1[ptr1]=nums2[ptr2]，最后ptr1++, ptr2++
        ///     如果queue.Peek()最小，那么将nums1[ptr1]放入队列，然后令nums1[ptr1]=queue.Dequeue()，最后ptr1++
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1.Length == m) return;
            if (n == 0) { nums1 = nums2; return; }

            Queue<int> queue = new Queue<int>();
            int ptr1 = 0, ptr2 = 0, qnum;
            while (ptr1 < m && ptr2 < n)
            {
                qnum = queue.Count == 0 ? int.MaxValue : queue.Peek();  // int.MaxValue相当于哨兵
                if (nums1[ptr1] <= nums2[ptr2] && nums1[ptr1] <= qnum)
                {
                    ptr1++;
                }
                else if (nums2[ptr2] <= nums1[ptr1] && nums2[ptr2] <= qnum)
                {
                    queue.Enqueue(nums1[ptr1]); nums1[ptr1] = nums2[ptr2];
                    ptr1++; ptr2++;
                }
                else  // qnum <= nums1[ptr1] && qnum <= nums2[ptr2]
                {
                    queue.Enqueue(nums1[ptr1]); nums1[ptr1] = queue.Dequeue();
                    ptr1++;
                }
            }
            while (ptr1 < m)      // ptr2 == n && queue.Count > 0
            {
                qnum = queue.Count == 0 ? int.MaxValue : queue.Peek();  // int.MaxValue相当于哨兵
                if (nums1[ptr1] > qnum) { queue.Enqueue(nums1[ptr1]); nums1[ptr1] = queue.Dequeue(); }
                ptr1++;
            }
            while (ptr2 < n)      // ptr1 == m && queue.Count > 0
            {
                qnum = queue.Count == 0 ? int.MaxValue : queue.Peek();  // int.MaxValue相当于哨兵
                if (nums2[ptr2] < qnum) nums1[ptr1++] = nums2[ptr2++]; else nums1[ptr1++] = queue.Dequeue();
            }
            while (ptr1 < m + n)  // queue.Count > 0
            {
                nums1[ptr1++] = queue.Dequeue();
            }
        }
    }
}
