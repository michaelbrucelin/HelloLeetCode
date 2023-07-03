using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0002
{
    public class Solution0002_3 : Interface0002
    {
        /// <summary>
        /// 双指针归并
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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
    }
}
