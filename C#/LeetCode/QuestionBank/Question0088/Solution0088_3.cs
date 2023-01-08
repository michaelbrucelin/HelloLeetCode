using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0088
{
    public class Solution0088_3 : Interface0088
    {
        /// <summary>
        /// 四指针
        /// 与Solution0088_2一样，但是这里没有使用队列，而是利用nums1后面的空间当作Solution0088_2中的队列来用
        /// 相比较Solution0088_2多的两个指针，就是模拟队列的数组范围
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

        /// <summary>
        /// 操作取与缓存区重叠，将缓存区移到数组的末端
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="top"></param>
        /// <param name="next"></param>
        private void MoveQueue(int[] nums, ref int top, ref int next)
        {
            int len = nums.Length - 1, _top = top, _next = next;
            for (int i = _top; i > _next; i--) nums[len - _top + i] = nums[i];
            top = len;
            next = top - _top + _next;
        }

        private void EnQueue(int[] nums, ref int top, ref int next, int border, int value)
        {
            if (next <= border) MoveQueue(nums, ref top, ref next);
            nums[next] = value;
            next--;
        }

        private int DeQueue(int[] nums, ref int top, ref int next)
        {
            return nums[top--];
        }
    }
}
