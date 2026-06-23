using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2039
{
    public class Test2039
    {
        public void Test()
        {
            Interface2039 solution = new Solution2039();
            int[][] edges; int[] patience;
            int result, answer;
            int id = 0;

            // 1. 
            edges = [[0, 1], [1, 2]]; patience = [0, 2, 1];
            answer = 8;
            result = solution.NetworkBecomesIdle(edges, patience);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = [[0, 1], [0, 2], [1, 2]]; patience = [0, 10, 10];
            answer = 3;
            result = solution.NetworkBecomesIdle(edges, patience);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            edges = [[5, 7], [15, 18], [12, 6], [5, 1], [11, 17], [3, 9], [6, 11], [14, 7], [19, 13], [13, 3], [4, 12], [9, 15], [2, 10], [18, 4], [5, 14], [17, 5], [16, 2], [7, 1], [0, 16], [10, 19], [1, 8]];
            patience = [0, 2, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1];
            answer = 67;
            result = solution.NetworkBecomesIdle(edges, patience);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
