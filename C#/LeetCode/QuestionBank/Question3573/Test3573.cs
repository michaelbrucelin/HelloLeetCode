using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3573
{
    public class Test3573
    {
        public void Test()
        {
            Interface3573 solution = new Solution3573_err();
            int[] prices; int k;
            long result, answer;
            int id = 0;

            // 1. 
            prices = [1, 7, 9, 8, 2]; k = 2;
            answer = 14;
            result = solution.MaximumProfit(prices, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            prices = [12, 16, 19, 19, 8, 1, 19, 13, 9]; k = 3;
            answer = 36;
            result = solution.MaximumProfit(prices, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            prices = [20, 20, 4, 3, 10, 16, 5, 1, 15, 18, 3]; k = 4;  // (20-4) + (16-3) + (15-1) + (18-3)
            answer = 58;
            result = solution.MaximumProfit(prices, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
