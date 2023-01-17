using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0203
{
    public class Solution0203_3 : Interface0203
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return head;

            ListNode dummyHead = new ListNode(0) { next = head };
            ListNode ptr = dummyHead;
            while (ptr.next != null)
            {
                if (ptr.next.val != val)
                    ptr = ptr.next;
                else
                    ptr.next = ptr.next.next;
            }

            return dummyHead.next;
        }
    }
}
