using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0924
{
    public class Test0924
    {
        public void Test()
        {
            Interface0924 solution = new Solution0924_3();
            int[][] graph; int[] initial;
            int result, answer;
            int id = 0;

            // 1. 
            graph = [[1, 1, 0], [1, 1, 0], [0, 0, 1]]; initial = [0, 1];
            answer = 0;
            result = solution.MinMalwareSpread(graph, initial);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            graph = [[1, 0, 0], [0, 1, 0], [0, 0, 1]]; initial = [0, 2];
            answer = 0;
            result = solution.MinMalwareSpread(graph, initial);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            graph = [[1, 1, 1], [1, 1, 1], [1, 1, 1]]; initial = [1, 2];
            answer = 1;
            result = solution.MinMalwareSpread(graph, initial);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            graph = [[1, 0, 0, 0], [0, 1, 0, 0], [0, 0, 1, 1], [0, 0, 1, 1]]; initial = [3, 1];
            answer = 3;
            result = solution.MinMalwareSpread(graph, initial);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            graph = [[1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1], [0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0], [0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0], [0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0],
                     [1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0], [0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0], [0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0], [0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0],
                     [0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0], [0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0], [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]];
            initial = [7, 8, 6, 2, 3];
            answer = 2;
            result = solution.MinMalwareSpread(graph, initial);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
