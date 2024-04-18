using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0928
{
    public class Test0928
    {
        public void Test()
        {
            Interface0928 solution = new Solution0928();
            int[][] graph; int[] initial;
            int result, answer;
            int id = 0;

            // 1. 
            graph = [[1, 1, 0], [1, 1, 0], [0, 0, 1]]; initial = [0, 1];
            answer = 0;
            result = solution.MinMalwareSpread(graph, initial);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            graph = [[1, 1, 0], [1, 1, 1], [0, 1, 1]]; initial = [0, 1];
            answer = 1;
            result = solution.MinMalwareSpread(graph, initial);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            graph = [[1, 1, 0, 0], [1, 1, 1, 0], [0, 1, 1, 1], [0, 0, 1, 1]]; initial = [0, 1];
            answer = 1;
            result = solution.MinMalwareSpread(graph, initial);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
