using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1353
{
    public class Test1353
    {
        public void Test()
        {
            Interface1353 solution = new Solution1353_err();
            int[][] events;
            int result, answer;
            int id = 0;

            // 1. 
            events = [[1, 2], [2, 3], [3, 4]];
            answer = 3;
            result = solution.MaxEvents(events);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            events = [[1, 2], [2, 3], [3, 4], [1, 2]];
            answer = 4;
            result = solution.MaxEvents(events);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            events = [[1, 2], [1, 2], [3, 3], [1, 5], [1, 5]];
            answer = 5;
            result = solution.MaxEvents(events);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
