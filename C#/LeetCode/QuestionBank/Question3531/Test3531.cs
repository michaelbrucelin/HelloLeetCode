using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3531
{
    public class Test3531
    {
        public void Test()
        {
            Interface3531 solution = new Solution3531();
            int n; int[][] buildings;
            int result, answer;
            int id = 0;

            // 1. 
            n = 3; buildings = [[1, 2], [2, 2], [3, 2], [2, 1], [2, 3]];
            answer = 1;
            result = solution.CountCoveredBuildings(n, buildings);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; buildings = [[1, 1], [1, 2], [2, 1], [2, 2]];
            answer = 0;
            result = solution.CountCoveredBuildings(n, buildings);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 5; buildings = [[1, 3], [3, 2], [3, 3], [3, 5], [5, 3]];
            answer = 1;
            result = solution.CountCoveredBuildings(n, buildings);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
