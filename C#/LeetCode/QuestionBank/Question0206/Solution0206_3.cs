using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0206
{
    public class Solution0206_3 : Interface0206
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode ptr = head;
            while (ptr != null) { stack.Push(ptr); ptr = ptr.next; }

            ListNode _head = stack.Pop();
            ptr = _head;
            while (stack.Count > 0) { ptr.next = stack.Pop(); ptr = ptr.next; }
            ptr.next = null;

            return _head;
        }
    }
}
