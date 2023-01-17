using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0203
{
    public class Solution0203_2 : Interface0203
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return head;

            head.next = RemoveElements(head.next, val);
            return head.val != val ? head : head.next;
        }
    }
}
