using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1665
{
    public class Test1665
    {
        public void Test()
        {
            Interface1665 solution = new Solution1665_err();
            int[][] tasks;
            int result, answer;
            int id = 0;

            // 1. 
            tasks = [[1, 2], [2, 4], [4, 8]];
            answer = 8;
            result = solution.MinimumEffort(tasks);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            tasks = [[1, 3], [2, 4], [10, 11], [10, 12], [8, 9]];
            answer = 32;
            result = solution.MinimumEffort(tasks);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            tasks = [[1, 7], [2, 8], [3, 9], [4, 10], [5, 11], [6, 12]];
            answer = 27;
            result = solution.MinimumEffort(tasks);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
