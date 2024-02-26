using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0206
{
    public class Test0206
    {
        public void Test()
        {
            Interface0206 solution = new Solution0206_2();
            ListNode head;
            bool result, answer;
            int id = 0;

            // 1. 
            head = new ListNode(1) { next = new ListNode(2) };
            answer = false;
            result = solution.IsPalindrome(head);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            head = new ListNode(1) { next = new ListNode(2) { next = new ListNode(2) { next = new ListNode(1) } } };
            answer = true;
            result = solution.IsPalindrome(head);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
