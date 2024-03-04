using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0203
{
    public class Test0203
    {
        public void Test()
        {
            Interface0203 solution = new Solution0203_2();
            ListNode result; int[] answer;
            int id = 0;

            // 1. 
            ListNode node9 = new ListNode(9);
            ListNode node1 = new ListNode(1) { next = node9 };
            ListNode node5 = new ListNode(5) { next = node1 };
            ListNode node4 = new ListNode(4) { next = node5 };
            solution.DeleteNode(node5);
            result = node4; answer = new int[] { 4, 1, 9 };
            Console.WriteLine($"{++id,2}: {(Verify(result, answer)) + ",",-6} result: {Dump(result)}, answer: {Dump(answer)}");
        }

        private bool Verify(ListNode result, int[] answer)
        {
            ListNode ptr = result; int id = 0, len = answer.Length;
            while (ptr != null && id < len)
            {
                if (ptr.val != answer[id]) return false;
                ptr = ptr.next; id++;
            }

            return ptr == null && id == len;
        }

        private string Dump(ListNode head)
        {
            StringBuilder result = new StringBuilder();
            ListNode ptr = head;
            while (ptr != null) { result.Append($"{ptr.val}->"); ptr = ptr.next; }
            result.Remove(result.Length - 2, 2);

            return result.ToString();
        }

        private string Dump(int[] arr)
        {
            return string.Join("->", arr.Select(i => i.ToString()));
        }
    }
}
