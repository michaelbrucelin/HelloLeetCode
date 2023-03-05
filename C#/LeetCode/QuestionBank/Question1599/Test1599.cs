using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1599
{
    public class Test1599
    {
        public void Test()
        {
            Interface1599 solution = new Solution1599();
            int[] customers; int boardingCost, runningCost;
            int result, answer;
            int id = 0;

            // 1. 
            customers = new int[] { 8, 3 }; boardingCost = 5; runningCost = 6; answer = 3;
            result = solution.MinOperationsMaxProfit(customers, boardingCost, runningCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            customers = new int[] { 10, 9, 6 }; boardingCost = 6; runningCost = 4; answer = 7;
            result = solution.MinOperationsMaxProfit(customers, boardingCost, runningCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            customers = new int[] { 3, 4, 0, 5, 1 }; boardingCost = 1; runningCost = 92; answer = -1;
            result = solution.MinOperationsMaxProfit(customers, boardingCost, runningCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            customers = new int[] { 3, 4, 4, 4, 3 }; boardingCost = 2; runningCost = 7; answer = 4;
            result = solution.MinOperationsMaxProfit(customers, boardingCost, runningCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            customers = new int[] { 3, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 }; boardingCost = 2; runningCost = 7; answer = 15;
            result = solution.MinOperationsMaxProfit(customers, boardingCost, runningCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            customers = new int[] { 4, 4, 4, 4 }; boardingCost = 2; runningCost = 8; answer = -1;
            result = solution.MinOperationsMaxProfit(customers, boardingCost, runningCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
