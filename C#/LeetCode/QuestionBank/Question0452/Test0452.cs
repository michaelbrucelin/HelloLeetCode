using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0452
{
    public class Test0452
    {
        public void Test()
        {
            Interface0452 solution = new Solution0452();
            int[][] points;
            int result, answer;
            int id = 0;

            // 1. 
            points = [[10, 16], [2, 8], [1, 6], [7, 12]];
            answer = 2;
            result = solution.FindMinArrowShots(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            points = [[1, 2], [3, 4], [5, 6], [7, 8]];
            answer = 4;
            result = solution.FindMinArrowShots(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            points = [[1, 2], [2, 3], [3, 4], [4, 5]];
            answer = 2;
            result = solution.FindMinArrowShots(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            points = [[-2147483646, -2147483645], [2147483646, 2147483647]];
            answer = 2;
            result = solution.FindMinArrowShots(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
