using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0143
{
    public class Test0143
    {
        public void Test()
        {
            Interface0143 solution = new Solution0143();
            ListNode head;
            ListNode answer;
            int id = 0;

            // 下面的验证不严谨，仅仅验证了节点的值，而没有验证节点本身
            // 1. 
            head = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) } } };
            answer = new ListNode(1) { next = new ListNode(4) { next = new ListNode(2) { next = new ListNode(3) } } };
            solution.ReorderList(head);
            Console.WriteLine($"{++id,2}: {(Verify(head, answer)) + ",",-6} result: {Output(head)}, answer: {Output(answer)}");

            // 2. 
            head = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) } } } };
            answer = new ListNode(1) { next = new ListNode(5) { next = new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } } } };
            solution.ReorderList(head);
            Console.WriteLine($"{++id,2}: {(Verify(head, answer)) + ",",-6} result: {Output(head)}, answer: {Output(answer)}");
        }

        private bool Verify(ListNode l1, ListNode l2)
        {
            ListNode p1 = l1, p2 = l2;
            while (p1 != null && p2 != null)
            {
                if (p1.val != p2.val) return false;
                p1 = p1.next; p2 = p2.next;
            }
            if (p1 != null || p2 != null) return false;

            return true;
        }

        private string Output(ListNode l)
        {
            StringBuilder result = new StringBuilder();
            ListNode p = l; result.Append("[ ");
            while (p != null) { result.Append($"{p.val}, "); p = p.next; }
            result.Remove(result.Length - 2, 2);
            result.Append(" ]");

            return result.ToString();
        }
    }
}
