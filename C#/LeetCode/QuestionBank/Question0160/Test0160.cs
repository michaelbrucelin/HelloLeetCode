using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0160
{
    public class Test0160
    {
        public void Test()
        {
            Interface0160 solution = new Solution0160_2();
            ListNode headA, headB;
            ListNode result, answer;
            int id = 0;

            // 1. 
            ((answer = new ListNode(8)).next = new ListNode(4)).next = new ListNode(5);
            ((headA = new ListNode(4)).next = new ListNode(1)).next = answer;
            (((headB = new ListNode(5)).next = new ListNode(6)).next = new ListNode(1)).next = answer;
            result = solution.GetIntersectionNode(headA, headB);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            (answer = new ListNode(2)).next = new ListNode(4);
            (((headA = new ListNode(1)).next = new ListNode(9)).next = new ListNode(1)).next = answer;
            (headB = new ListNode(3)).next = answer;
            result = solution.GetIntersectionNode(headA, headB);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            answer = null;
            (((headA = new ListNode(2)).next = new ListNode(6)).next = new ListNode(4)).next = answer;
            ((headB = new ListNode(1)).next = new ListNode(5)).next = answer;
            result = solution.GetIntersectionNode(headA, headB);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            answer = new ListNode(1);
            headA = answer;
            headB = answer;
            result = solution.GetIntersectionNode(headA, headB);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            answer = null;
            (((((((((((headA = new ListNode(1)).next = new ListNode(3)).next = new ListNode(5)).next = new ListNode(7)).next = new ListNode(9)).next = new ListNode(11)).next
                = new ListNode(13)).next = new ListNode(15)).next = new ListNode(17)).next = new ListNode(19)).next = new ListNode(21)).next = answer;
            (headB = new ListNode(2)).next = answer;
            result = solution.GetIntersectionNode(headA, headB);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
