using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0445
{
    public class Solution0445 : Interface0445
    {
        /// <summary>
        /// 翻转链表
        /// 1. 翻转链表l1与l2
        /// 2. 两数相加结果放在链表l中
        /// 3. 翻转链表l
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            l1 = Reverse(l1); l2 = Reverse(l2);
            ListNode node = Add(l1, l2);

            return Reverse(node);
        }

        private ListNode Add(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode ptr = dummy, ptr1 = l1, ptr2 = l2; int extra = 0;
            while (ptr1 != null && ptr2 != null)
            {
                ptr.next = new ListNode((ptr1.val + ptr2.val + extra) % 10);
                extra = (ptr1.val + ptr2.val + extra) / 10;
                ptr = ptr.next; ptr1 = ptr1.next; ptr2 = ptr2.next;
            }
            while (ptr1 != null)
            {
                ptr.next = new ListNode((ptr1.val + extra) % 10);
                extra = (ptr1.val + extra) / 10;
                ptr = ptr.next; ptr1 = ptr1.next;
            }
            while (ptr2 != null)
            {
                ptr.next = new ListNode((ptr2.val + extra) % 10);
                extra = (ptr2.val + extra) / 10;
                ptr = ptr.next; ptr2 = ptr2.next;
            }
            if (extra != 0) ptr.next = new ListNode(extra);

            return dummy.next;
        }

        private ListNode Reverse(ListNode l)
        {
            if (l == null) return null;

            ListNode p1 = null, p2 = l, p3;
            while (p2 != null)
            {
                p3 = p2.next; p2.next = p1; p1 = p2; p2 = p3;
            }

            return p1;
        }
    }
}
