using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0322
{
    public class Test0322
    {
        public void Test()
        {
            Interface0322 solution = new Solution0322_4();
            int[] coins; int amount;
            int result, answer;
            int id = 0;

            // 1. 
            coins = new int[] { 1, 2, 5 }; amount = 11;
            answer = 3;
            result = solution.CoinChange(coins, amount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            coins = new int[] { 2 }; amount = 3;
            answer = -1;
            result = solution.CoinChange(coins, amount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            coins = new int[] { 1 }; amount = 0;
            answer = 0;
            result = solution.CoinChange(coins, amount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            coins = new int[] { 1, 2, 5 }; amount = 100;
            answer = 20;
            result = solution.CoinChange(coins, amount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
