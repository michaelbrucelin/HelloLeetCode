using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0725
{
    public class Test0725
    {
        public void Test()
        {
            Interface0725 solution = new Solution0725();
            ListNode head; int k;
            ListNode[] result, answer;
            int id = 0;

            // 1. 
            head = new ListNode(1, new ListNode(2, new ListNode(3))); k = 5;
            solution.SplitListToParts(head, k);

            // 2. 
            head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(8, new ListNode(9, new ListNode(10)))))))))); k = 3;
            solution.SplitListToParts(head, k);
        }
    }
}
