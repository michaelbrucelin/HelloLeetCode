using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2685
{
    public class Test2685
    {
        public void Test()
        {
            Interface2685 solution = new Solution2685_3();
            int n; int[][] edges;
            int result, answer;
            int id = 0;

            // 1. 
            n = 6; edges = [[0, 1], [0, 2], [1, 2], [3, 4]];
            answer = 3;
            result = solution.CountCompleteComponents(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 6; edges = [[0, 1], [0, 2], [1, 2], [3, 4], [3, 5]];
            answer = 1;
            result = solution.CountCompleteComponents(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
