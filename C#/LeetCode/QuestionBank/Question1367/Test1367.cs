using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1367
{
    public class Test1367
    {
        public void Test()
        {
            Interface1367 solution = new Solution1367();
            ListNode head; TreeNode root;
            bool result, answer;
            int id = 0;

            // 1. 
            head = new ListNode(4) { next = new ListNode(2) { next = new ListNode(8) } };
            root = new TreeNode(1)
            {
                left = new TreeNode(4) { right = new TreeNode(2) { left = new TreeNode(1) } },
                right = new TreeNode(4) { left = new TreeNode(2) { left = new TreeNode(6), right = new TreeNode(8) { left = new TreeNode(1), right = new TreeNode(3) } } }
            };
            answer = true;
            result = solution.IsSubPath(head, root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            head = new ListNode(1) { next = new ListNode(4) { next = new ListNode(2) { next = new ListNode(6) } } };
            root = new TreeNode(1)
            {
                left = new TreeNode(4) { right = new TreeNode(2) { left = new TreeNode(1) } },
                right = new TreeNode(4) { left = new TreeNode(2) { left = new TreeNode(6), right = new TreeNode(8) { left = new TreeNode(1), right = new TreeNode(3) } } }
            };
            answer = true;
            result = solution.IsSubPath(head, root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            head = new ListNode(1) { next = new ListNode(4) { next = new ListNode(2) { next = new ListNode(6) { next = new ListNode(8) } } } };
            root = new TreeNode(1)
            {
                left = new TreeNode(4) { right = new TreeNode(2) { left = new TreeNode(1) } },
                right = new TreeNode(4) { left = new TreeNode(2) { left = new TreeNode(6), right = new TreeNode(8) { left = new TreeNode(1), right = new TreeNode(3) } } }
            };
            answer = false;
            result = solution.IsSubPath(head, root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
