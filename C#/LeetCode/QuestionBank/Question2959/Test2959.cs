using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2959
{
    public class Test2959
    {
        public void Test()
        {
            Interface2959 solution = new Solution2959_2();
            int n, maxDistance; int[][] roads;
            int result, answer;
            int id = 0;

            // 1. 
            n = 3; maxDistance = 5; roads = [[0, 1, 2], [1, 2, 10], [0, 2, 10]];
            answer = 5;
            result = solution.NumberOfSets(n, maxDistance, roads);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; maxDistance = 5; roads = [[0, 1, 20], [0, 1, 10], [1, 2, 2], [0, 2, 2]];
            answer = 7;
            result = solution.NumberOfSets(n, maxDistance, roads);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1; maxDistance = 10; roads = [];
            answer = 2;
            result = solution.NumberOfSets(n, maxDistance, roads);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 3; maxDistance = 12; roads = [[1, 0, 11], [1, 0, 16], [0, 2, 13]];
            answer = 5;
            result = solution.NumberOfSets(n, maxDistance, roads);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
