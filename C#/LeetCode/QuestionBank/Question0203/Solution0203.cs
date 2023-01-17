using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0203
{
    public class Solution0203 : Interface0203
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return head;

            ListNode ptr = head;
            while (ptr != null && ptr.val == val) ptr = ptr.next;
            if (ptr == null) return null;

            ListNode prev = new ListNode(), _head = ptr;
            while (ptr != null)
            {
                if (ptr.val != val)
                {
                    prev = ptr; ptr = ptr.next;
                }
                else
                {
                    prev.next = ptr.next; ptr = ptr.next;
                }
            }

            return _head;
        }
    }
}
