using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2130
{
    public class Test2130
    {
        public void Test()
        {
            Interface2130 solution = new Solution2130_3();
            ListNode head;
            int result, answer;
            int id = 0;

            // 1. 
            head = new ListNode(5, new ListNode(4, new ListNode(2, new ListNode(1))));
            answer = 6;
            result = solution.PairSum(head);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            head = new ListNode(4, new ListNode(2, new ListNode(2, new ListNode(3))));
            answer = 7;
            result = solution.PairSum(head);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            head = new ListNode(1, new ListNode(100000));
            answer = 100001;
            result = solution.PairSum(head);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
