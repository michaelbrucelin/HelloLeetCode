using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0021
{
    public class Solution0021 : Interface0021
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(-1, head);
            ListNode p1 = dummy, p2 = head;
            for (int i = 1; i < n; i++) p2 = p2.next;
            while (p2.next != null) { p1 = p1.next; p2 = p2.next; }
            p1.next = p1.next.next;

            return dummy.next;
        }
    }
}
