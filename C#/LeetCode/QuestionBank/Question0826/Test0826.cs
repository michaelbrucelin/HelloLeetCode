using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0826
{
    public class Test0826
    {
        public void Test()
        {
            Interface0826 solution = new Solution0826_2();
            int[] difficulty, profit, worker;
            int result, answer;
            int id = 0;

            // 1. 
            difficulty = [2, 4, 6, 8, 10]; profit = [10, 20, 30, 40, 50]; worker = [4, 5, 6, 7];
            answer = 100;
            result = solution.MaxProfitAssignment(difficulty, profit, worker);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            difficulty = [85, 47, 57]; profit = [24, 66, 99]; worker = [40, 25, 25];
            answer = 0;
            result = solution.MaxProfitAssignment(difficulty, profit, worker);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            difficulty = [68, 35, 52, 47, 86]; profit = [67, 17, 1, 81, 3]; worker = [92, 10, 85, 84, 82];
            answer = 324;
            result = solution.MaxProfitAssignment(difficulty, profit, worker);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
