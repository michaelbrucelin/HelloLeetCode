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
        /// 
        /// 这个解法没有实际意义，只是玩玩写着的，除非内存真的那么不够用，现实中貌似不存在这种情况
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1.Length == m) return;
            if (n == 0) { nums1 = nums2; return; }

            int ptr1 = 0, ptr2 = 0, ptrTop = m + n - 1, ptrNext = m + n - 1, qnum;
            while (ptr1 < m && ptr2 < n)
            {
                qnum = ptrTop == ptrNext ? int.MaxValue : PeekQueue(nums1, ref ptrTop, ref ptrNext);  // int.MaxValue相当于哨兵
                if (nums1[ptr1] <= nums2[ptr2] && nums1[ptr1] <= qnum)
                {
                    ptr1++;
                }
                else if (nums2[ptr2] <= nums1[ptr1] && nums2[ptr2] <= qnum)
                {
                    EnQueue(nums1, ref ptrTop, ref ptrNext, Math.Max(m - 1, ptr1), nums1[ptr1]); nums1[ptr1] = nums2[ptr2];
                    ptr1++; ptr2++;
                }
                else  // qnum <= nums1[ptr1] && qnum <= nums2[ptr2]
                {
                    EnQueue(nums1, ref ptrTop, ref ptrNext, Math.Max(m - 1, ptr1), nums1[ptr1]);
                    nums1[ptr1] = DeQueue(nums1, ref ptrTop, ref ptrNext);
                    ptr1++;
                }
            }
            while (ptr2 < n)        // ptr1 == m && queue.Count > 0
            {
                qnum = ptrTop == ptrNext ? int.MaxValue : PeekQueue(nums1, ref ptrTop, ref ptrNext);  // int.MaxValue相当于哨兵
                if (ptr1 > ptrNext) MoveQueue(nums1, ref ptrTop, ref ptrNext);
                if (nums2[ptr2] < qnum) nums1[ptr1++] = nums2[ptr2++]; else nums1[ptr1++] = DeQueue(nums1, ref ptrTop, ref ptrNext);
            }
            if (ptr1 < m)           // ptr2 == n && queue.Count > 0，队列部分移到前面即可，例如5,6,7,2,1，后两个元素是队列，调整为1,2,5,6,7
            {
                int cnt = ptrTop - ptrNext, tail = nums1.Length - 1;
                for (int i = 0; i < ptrTop - ptrNext; i++)
                {
                    int t = nums1[tail];
                    for (int j = tail; j > ptr1; j--) nums1[j] = nums1[j - 1];
                    nums1[ptr1++] = t;
                }
            }
            else if (ptr1 < m + n)  // queue.Count > 0，队列部分反序即可
            {
                int left = ptr1, right = m + n - 1;
                while (left < right)
                {
                    int t = nums1[left]; nums1[left] = nums1[right]; nums1[right] = t;
                    left++; right--;
                }
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
            if (next <= border)
            {
                if (top == nums.Length - 1) throw new Exception("there is no space for new element.");
                MoveQueue(nums, ref top, ref next);
            }
            nums[next] = value;
            next--;
        }

        private int DeQueue(int[] nums, ref int top, ref int next)
        {
            if (top == next) throw new Exception("there is no element in queue.");
            return nums[top--];
        }

        private int PeekQueue(int[] nums, ref int top, ref int next)
        {
            if (top == next) throw new Exception("there is no element in queue.");
            return nums[top];
        }
    }
}
