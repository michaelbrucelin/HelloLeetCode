using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2326
{
    public class Test2326
    {
        public void Test()
        {
            Interface2326 solution = new Solution2326();
            int m, n; ListNode head;
            int[][] result, answer;
            int id = 0;

            // 1. 
            m = 3; n = 5;
            head = new ListNode(3, new ListNode(0, new ListNode(2, new ListNode(6, new ListNode(8, new ListNode(1, new ListNode(7, new ListNode(9, new ListNode(4, new ListNode(2, new ListNode(5, new ListNode(5, new ListNode(0)))))))))))));
            answer = [[3, 0, 2, 6, 8], [5, 0, -1, -1, 1], [5, 2, 4, 9, 7]];
            result = solution.SpiralMatrix(m, n, head);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            m = 1; n = 4;
            head = new ListNode(0, new ListNode(1, new ListNode(2)));
            answer = [[0, 1, 2, -1]];
            result = solution.SpiralMatrix(m, n, head);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}
