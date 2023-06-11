using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1171
{
    public class Test1171
    {
        public void Test()
        {
            Interface1171 solution = new Solution1171();
            ListNode head;
            // ListNode result, answer;
            // int id = 0;

            // 1. 
            head = new ListNode(1, new ListNode(2, new ListNode(-3, new ListNode(3, new ListNode(1)))));
            solution.RemoveZeroSumSublists(head);

            // 2. 
            head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(-3, new ListNode(4)))));
            solution.RemoveZeroSumSublists(head);

            // 3. 
            head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(-3, new ListNode(-2)))));
            solution.RemoveZeroSumSublists(head);
        }
    }
}
