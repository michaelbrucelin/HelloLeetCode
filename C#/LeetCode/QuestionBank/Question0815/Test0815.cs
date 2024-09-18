using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0815
{
    public class Test0815
    {
        public void Test()
        {
            Interface0815 solution = new Solution0815();
            int[][] routes; int source, target;
            int result, answer;
            int id = 0;

            // 1. 
            routes = [[1, 2, 7], [3, 6, 7]]; source = 1; target = 6;
            answer = 2;
            result = solution.NumBusesToDestination(routes, source, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            routes = [[7, 12], [4, 5, 15], [6], [15, 19], [9, 12, 13]]; source = 15; target = 12;
            answer = -1;
            result = solution.NumBusesToDestination(routes, source, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            routes = [[1, 2, 7], [3, 6, 7]]; source = 8; target = 6;
            answer = -1;
            result = solution.NumBusesToDestination(routes, source, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
