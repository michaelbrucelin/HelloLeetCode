using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2303
{
    public class Test2303
    {
        public void Test()
        {
            Interface2303 solution = new Solution2303();
            int[][] brackets; int income;
            double result, answer;
            int id = 0;

            // 1. 
            brackets = new int[][] { new int[] { 3, 50 }, new int[] { 7, 10 }, new int[] { 12, 25 } };
            income = 10; answer = 2.65000D;
            result = solution.CalculateTax(brackets, income);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            brackets = new int[][] { new int[] { 1, 0 }, new int[] { 4, 25 }, new int[] { 5, 50 } };
            income = 2; answer = 0.25000D;
            result = solution.CalculateTax(brackets, income);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            brackets = new int[][] { new int[] { 2, 50 } };
            income = 0; answer = 0.00000D;
            result = solution.CalculateTax(brackets, income);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
