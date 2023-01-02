using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1801
{
    public class Test1801
    {
        public void Test()
        {
            Interface1801 solution = new Solution1801_2();
            int[][] orders;
            int result, answer;
            int id = 0;

            // 1.
            orders = new int[][] { new int[] { 10, 5, 0 }, new int[] { 15, 2, 1 }, new int[] { 25, 1, 1 }, new int[] { 30, 4, 0 } };
            answer = 6; result = solution.GetNumberOfBacklogOrders(orders);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            orders = new int[][] { new int[] { 7, 1000000000, 1 }, new int[] { 15, 3, 0 }, new int[] { 5, 999999995, 0 }, new int[] { 5, 1, 1 } };
            answer = 999999984; result = solution.GetNumberOfBacklogOrders(orders);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
