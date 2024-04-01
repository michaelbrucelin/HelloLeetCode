using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2952
{
    public class Test2952
    {
        public void Test()
        {
            Interface2952 solution = new Solution2952();
            int[] coins; int target;
            int result, answer;
            int id = 0;

            // 1. 
            coins = [1, 4, 10]; target = 19;
            answer = 2;
            result = solution.MinimumAddedCoins(coins, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            coins = [1, 4, 10, 5, 7, 19]; target = 19;
            answer = 1;
            result = solution.MinimumAddedCoins(coins, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            coins = [1, 1, 1]; target = 20;
            answer = 3;
            result = solution.MinimumAddedCoins(coins, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
