using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0024
{
    public class Solution0024_oth : Interface0024
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode dummy = new ListNode();
            ListNode ptr1 = dummy, ptr2 = head;

            Stack<ListNode> stack = new Stack<ListNode>();
            while (ptr2 != null && ptr2.next != null)
            {
                stack.Push(ptr2); ptr2 = ptr2.next;
                stack.Push(ptr2); ptr2 = ptr2.next;
                ptr1.next = stack.Pop(); ptr1 = ptr1.next;
                ptr1.next = stack.Pop(); ptr1 = ptr1.next;
            }
            ptr1.next = ptr2;

            return dummy.next;
        }
    }
}
