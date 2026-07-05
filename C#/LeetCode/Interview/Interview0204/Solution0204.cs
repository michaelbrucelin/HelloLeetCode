using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0204
{
    public class Solution0204 : Interface0204
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null) return null;

            ListNode dummy1 = new ListNode(), dummy2 = new ListNode();
            ListNode p1 = dummy1, p2 = dummy2, ptr = head;
            while (ptr != null)
            {
                if (ptr.val < x) { p1.next = ptr; p1 = ptr; } else { p2.next = ptr; p2 = ptr; }
                ptr = ptr.next;
            }
            p1.next = p2.next = null;

            if (dummy1.next == null || dummy2.next == null) return head;
            p1.next = dummy2.next;
            return dummy1.next;
        }
    }
}
