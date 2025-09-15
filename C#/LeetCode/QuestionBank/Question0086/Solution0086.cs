using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0086
{
    public class Solution0086 : Interface0086
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null) return head;

            ListNode dummy1 = new ListNode(), dummy2 = new ListNode();
            ListNode ptr = head, ptr1 = dummy1, ptr2 = dummy2;
            while (ptr != null)
            {
                if (ptr.val < x) { ptr1.next = ptr; ptr1 = ptr1.next; }
                else { ptr2.next = ptr; ptr2 = ptr2.next; }
                ptr = ptr.next;
            }
            if (dummy1.next == null) { ptr2.next = null; return dummy2.next; }
            if (dummy2.next == null) { ptr1.next = null; return dummy1.next; }

            ptr1.next = dummy2.next;
            ptr2.next = null;
            return dummy1.next;
        }
    }
}
