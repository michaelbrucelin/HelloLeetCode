using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3418
{
    public class Test3418
    {
        public void Test()
        {
            Interface3418 solution = new Solution3418();
            int[][] coins;
            int result, answer;
            int id = 0;

            // 1. 
            coins = [[0, 1, -1], [1, -2, 3], [2, -3, 4]];
            answer = 8;
            result = solution.MaximumAmount(coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            coins = [[10, 10, 10], [10, 10, 10]];
            answer = 40;
            result = solution.MaximumAmount(coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            coins = [[-7, 12, 12, 13], [-6, 19, 19, -6], [9, -2, -10, 16], [-4, 14, -10, -9]];
            answer = 60;
            result = solution.MaximumAmount(coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            coins = [[4, -16, 1, -11], [6, 18, -17, 14], [16, -10, 9, 3], [-11, 17, 0, -11]];
            answer = 45;
            result = solution.MaximumAmount(coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
