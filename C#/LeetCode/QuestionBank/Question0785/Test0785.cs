using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0785
{
    public class Test0785
    {
        public void Test()
        {
            Interface0785 solution = new Solution0785();
            int[][] graph;
            bool result, answer;
            int id = 0;

            // 1. 
            graph = [[1, 2, 3], [0, 2], [0, 1, 3], [0, 2]];
            answer = false;
            result = solution.IsBipartite(graph);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            graph = [[1, 3], [0, 2], [1, 3], [0, 2]];
            answer = true;
            result = solution.IsBipartite(graph);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            graph = [[1], [0, 3], [3], [1, 2]];
            answer = true;
            result = solution.IsBipartite(graph);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
