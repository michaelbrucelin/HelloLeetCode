using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0206
{
    public class Solution0206_4 : Interface0206
    {
        public ListNode ReverseList(ListNode head)
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
