using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0445
{
    public class Test0445
    {
        public void Test()
        {
            Interface0445 solution = new Solution0445_oth();
            ListNode l1, l2;
            ListNode result, answer;
            int id = 0;

            // 1. 
            // l1 = new ListNode(7) { next = new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } } };
            l1 = ToListNode("[7,2,4,3]"); l2 = ToListNode("[5,6,4]");
            answer = ToListNode("[7,8,0,7]");
            result = solution.AddTwoNumbers(l1, l2);
            Console.WriteLine($"{++id,2}: {(Verify(result, answer)) + ",",-6} result: {ToString(result)}, answer: {ToString(answer)}");

            // 2. 
            l1 = ToListNode("[2,4,3]"); l2 = ToListNode("[5,6,4]");
            answer = ToListNode("[8,0,7]");
            result = solution.AddTwoNumbers(l1, l2);
            Console.WriteLine($"{++id,2}: {(Verify(result, answer)) + ",",-6} result: {ToString(result)}, answer: {ToString(answer)}");

            // 3. 
            l1 = ToListNode("[0]"); l2 = ToListNode("[0]");
            answer = ToListNode("[0]");
            result = solution.AddTwoNumbers(l1, l2);
            Console.WriteLine($"{++id,2}: {(Verify(result, answer)) + ",",-6} result: {ToString(result)}, answer: {ToString(answer)}");

            // 4. 
            l1 = ToListNode("[9,9,9,9,9,9,9,9,9]"); l2 = ToListNode("[1,1,1,1,1]");
            answer = ToListNode("[1,0,0,0,0,1,1,1,1,0]");
            result = solution.AddTwoNumbers(l1, l2);
            Console.WriteLine($"{++id,2}: {(Verify(result, answer)) + ",",-6} result: {ToString(result)}, answer: {ToString(answer)}");

            // 5. 
            l1 = ToListNode("[9,9,9,9,9,9,9,9,9]"); l2 = ToListNode("[1]");
            answer = ToListNode("[1,0,0,0,0,0,0,0,0,0]");
            result = solution.AddTwoNumbers(l1, l2);
            Console.WriteLine($"{++id,2}: {(Verify(result, answer)) + ",",-6} result: {ToString(result)}, answer: {ToString(answer)}");

            // 6. 
            l1 = ToListNode("[8,9,9]"); l2 = ToListNode("[2]");
            answer = ToListNode("[9,0,1]");
            result = solution.AddTwoNumbers(l1, l2);
            Console.WriteLine($"{++id,2}: {(Verify(result, answer)) + ",",-6} result: {ToString(result)}, answer: {ToString(answer)}");
        }

        private bool Verify(ListNode l1, ListNode l2)
        {
            while (l1 != null || l2 != null)
            {
                if (l1 == null || l2 == null || l1.val != l2.val) return false;
                l1 = l1.next; l2 = l2.next;
            }

            return true;
        }

        private ListNode ToListNode(string s)
        {
            ListNode dummy = new ListNode();
            var query = s[1..^1].Split(',').Select(int.Parse);
            ListNode ptr = dummy;
            foreach (int i in query)
            {
                ptr.next = new ListNode(i); ptr = ptr.next;
            }

            return dummy.next;
        }

        private string ToString(ListNode l)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            while (l != null)
            {
                sb.Append($"{l.val}, "); l = l.next;
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(" ]");

            return sb.ToString();
        }
    }
}
