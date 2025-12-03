using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3625
{
    public class Test3625
    {
        public void Test()
        {
            Interface3625 solution = new Solution3625_err();
            int[][] points;
            int result, answer;
            int id = 0;

            // 1. 
            points = [[-3, 2], [3, 0], [2, 3], [3, 2], [2, -3]];
            answer = 2;
            result = solution.CountTrapezoids(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            points = [[0, 0], [1, 0], [0, 1], [2, 1]];
            answer = 1;
            result = solution.CountTrapezoids(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            points = [[0, 0], [3, 0], [0, 3], [3, 3]];
            answer = 1;
            result = solution.CountTrapezoids(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            points = [[71, -89], [-75, -89], [-9, 11], [-24, -89], [-51, -89], [-77, -89], [42, 11]];
            answer = 10;
            result = solution.CountTrapezoids(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
