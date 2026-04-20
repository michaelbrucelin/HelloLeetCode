using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2074
{
    public class Test2074
    {
        public void Test()
        {
            Interface2074 solution = new Solution2074();
            ListNode head;
            ListNode result, answer;
            List<int> _result, _answer;
            int id = 0;

            // 1. 
            head = new ListNode(5, new ListNode(2, new ListNode(6, new ListNode(3, new ListNode(9, new ListNode(1, new ListNode(7, new ListNode(3, new ListNode(8, new ListNode(4))))))))));
            answer = new ListNode(5, new ListNode(6, new ListNode(2, new ListNode(3, new ListNode(9, new ListNode(1, new ListNode(4, new ListNode(8, new ListNode(3, new ListNode(7))))))))));
            result = solution.ReverseEvenLengthGroups(head);
            _result = link2list(result); _answer = link2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");

            // 2. 
            head = new ListNode(1, new ListNode(1, new ListNode(0, new ListNode(6))));
            answer = new ListNode(1, new ListNode(0, new ListNode(1, new ListNode(6))));
            result = solution.ReverseEvenLengthGroups(head);
            _result = link2list(result); _answer = link2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");

            // 3. 
            head = new ListNode(2, new ListNode(1));
            answer = new ListNode(2, new ListNode(1));
            result = solution.ReverseEvenLengthGroups(head);
            _result = link2list(result); _answer = link2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");

            // 4. 
            head = new ListNode(1, new ListNode(1, new ListNode(0, new ListNode(6, new ListNode(5)))));
            answer = new ListNode(1, new ListNode(0, new ListNode(1, new ListNode(5, new ListNode(6)))));
            result = solution.ReverseEvenLengthGroups(head);
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
