using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0148
{
    public class Test0148
    {
        public void Test()
        {
            Interface0148 solution = new Solution0148_2();
            ListNode head;
            ListNode result, answer;
            List<int> _result, _answer;
            int id = 0;

            // 1. head = [4,2,1,3], answer = [1,2,3,4]
            head = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
            answer = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            result = solution.SortList(head);
            _result = link2list(result); _answer = link2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");

            // 2. head = [-1,5,3,4,0], answer = [-1,0,3,4,5]
            head = new ListNode(-1, new ListNode(5, new ListNode(3, new ListNode(4, new ListNode(0)))));
            answer = new ListNode(-1, new ListNode(0, new ListNode(3, new ListNode(4, new ListNode(5)))));
            result = solution.SortList(head);
            _result = link2list(result); _answer = link2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");

            // 3. head = [], answer = []
            head = null;
            answer = null;
            result = solution.SortList(head);
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
