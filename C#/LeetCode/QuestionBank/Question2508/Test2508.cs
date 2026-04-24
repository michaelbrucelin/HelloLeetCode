using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2508
{
    public class Test2508
    {
        public void Test()
        {
            Interface2508 solution = new Solution2508();
            int n; IList<IList<int>> edges;
            bool result, answer;
            int id = 0;

            // 1. 
            n = 5; edges = [[1, 2], [2, 3], [3, 4], [4, 2], [1, 4], [2, 5]];
            answer = true;
            result = solution.IsPossible(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 4; edges = [[1, 2], [3, 4]];
            answer = true;
            result = solution.IsPossible(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 4; edges = [[1, 2], [1, 3], [1, 4]];
            answer = false;
            result = solution.IsPossible(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
