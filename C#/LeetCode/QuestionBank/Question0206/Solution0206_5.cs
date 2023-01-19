using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0206
{
    public class Solution0206_5 : Interface0206
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode _head = ReverseList(head.next);
            head.next.next = head;
            head.next = null;

            return _head;
        }
    }
}
