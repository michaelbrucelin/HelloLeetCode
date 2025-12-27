using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2402
{
    public class Test2402
    {
        public void Test()
        {
            Interface2402 solution = new Solution2402();
            int n; int[][] meetings;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2; meetings = [[0, 10], [1, 5], [2, 7], [3, 4]];
            answer = 0;
            result = solution.MostBooked(n, meetings);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; meetings = [[1, 20], [2, 10], [3, 5], [4, 9], [6, 8]];
            answer = 1;
            result = solution.MostBooked(n, meetings);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 4; meetings = [[18, 19], [3, 12], [17, 19], [2, 13], [7, 10]];
            answer = 0;
            result = solution.MostBooked(n, meetings);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
