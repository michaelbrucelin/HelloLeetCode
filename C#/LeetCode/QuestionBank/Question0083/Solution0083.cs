using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0083
{
    public class Solution0083 : Interface0083
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;

            ListNode ptr = head;
            while (ptr != null)
            {
                while (ptr.next != null && ptr.next.val == ptr.val) ptr.next = ptr.next.next;
                ptr = ptr.next;
            }

            return head;
        }

        public ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null) return null;

            ListNode ptr = head;
            while (ptr.next != null)
            {
                if (ptr.next.val == ptr.val)
                    ptr.next = ptr.next.next;
                else
                    ptr = ptr.next;
            }

            return head;
        }
    }
}
