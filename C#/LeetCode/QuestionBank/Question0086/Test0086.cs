using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0086
{
    public class Test0086
    {
        public void Test()
        {
            Interface0086 solution = new Solution0086_err();
            ListNode head; int x;
            ListNode result, answer;
            List<int> _result, _answer;
            int id = 0;

            // 1. 
            head = new ListNode(1, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(5, new ListNode(2))))));
            x = 3;
            answer = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(4, new ListNode(3, new ListNode(5))))));
            result = solution.Partition(head, x);
            _result = link2list(result); _answer = link2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");

            // 2. 
            head = new ListNode(2, new ListNode(1));
            x = 2;
            answer = new ListNode(1, new ListNode(2));
            result = solution.Partition(head, x);
            _result = link2list(result); _answer = link2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");
        }

        private List<int> link2list(ListNode head)
        {
            if (head == null) return [];
            List<int> list = [];
            ListNode ptr = head;
            while (ptr != null) { list.Add(ptr.val); ptr = ptr.next; }
            return list;
        }
    }
}
