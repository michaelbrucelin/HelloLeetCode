using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0234
{
    public class Solution0234_5 : Interface0234
    {
        /// <summary>
        /// 反转链表的后半部分
        /// 尽管函数结束前将链表改回，但是觉得还是在极端内存紧缺的情况下再用吧
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            if (head.next == null) return true;
            if (head.next.next == null) return head.val == head.next.val;

            var info = GetBorder(head);
            ListNode _head = ReverseList(info.right_head);

            bool result = true;
            ListNode ptr1 = head, ptr2 = _head;
            while (ptr2 != null)
            {
                if (ptr2.val != ptr1.val) { result = false; break; }
                ptr1 = ptr1.next; ptr2 = ptr2.next;
            }

            info.left_tail.next = ReverseList(_head);

            return result;
        }

        private (ListNode left_tail, ListNode right_head) GetBorder(ListNode head)
        {
            if (head == null || head.next == null) return (null, null);

            ListNode slow = head, fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next; fast = fast.next.next;
            }

            return (slow, slow.next);
        }

        private ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode prev = null, curr = head, next;
            while (curr != null)
            {
                next = curr.next; curr.next = prev; prev = curr; curr = next;
            }

            return prev;
        }
    }
}
