using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1584
{
    public class Test1584
    {
        public void Test()
        {
            Interface1584 solution = new Solution1584_2();
            int[][] points;
            int result, answer;
            int id = 0;

            // 1. 
            points = [[0, 0], [2, 2], [3, 10], [5, 2], [7, 0]];
            answer = 20;
            result = solution.MinCostConnectPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            points = [[3, 12], [-2, 5], [-4, 1]];
            answer = 18;
            result = solution.MinCostConnectPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            points = [[0, 0], [1, 1], [1, 0], [-1, 1]];
            answer = 4;
            result = solution.MinCostConnectPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            points = [[-1000000, -1000000], [1000000, 1000000]];
            answer = 4000000;
            result = solution.MinCostConnectPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            points = [[0, 0]];
            answer = 0;
            result = solution.MinCostConnectPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            points = [[2, -3], [-17, -8], [13, 8], [-17, -15]];
            answer = 53;
            result = solution.MinCostConnectPoints(points);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
