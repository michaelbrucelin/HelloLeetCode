using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3249
{
    public class Test3249
    {
        public void Test()
        {
            Interface3249 solution = new Solution3249_2();
            int[][] edges;
            int result, answer;
            int id = 0;

            // 1. 
            edges = [[0, 1], [0, 2], [1, 3], [1, 4], [2, 5], [2, 6]];
            answer = 7;
            result = solution.CountGoodNodes(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = [[0, 1], [1, 2], [2, 3], [3, 4], [0, 5], [1, 6], [2, 7], [3, 8]];
            answer = 6;
            result = solution.CountGoodNodes(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            edges = [[0, 1], [1, 2], [1, 3], [1, 4], [0, 5], [5, 6], [6, 7], [7, 8], [0, 9], [9, 10], [9, 12], [10, 11]];
            answer = 12;
            result = solution.CountGoodNodes(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
