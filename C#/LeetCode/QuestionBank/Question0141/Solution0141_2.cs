using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0141
{
    public class Solution0141_2 : Interface0141
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null) return false;
            if (head.next == head) return true;

            ListNode slow = head.next, fast = head.next.next;
            while (fast != null)
            {
                if (fast == slow) return true;
                if (fast.next == null) return false;
                slow = slow.next;
                fast = fast.next.next;
            }

            return false;
        }
    }
}
