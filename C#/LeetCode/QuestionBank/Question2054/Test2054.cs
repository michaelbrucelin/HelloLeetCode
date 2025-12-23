using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2054
{
    public class Test2054
    {
        public void Test()
        {
            Interface2054 solution = new Solution2054();
            int[][] events;
            int result, answer;
            int id = 0;

            // 1. 
            events = [[1, 3, 2], [4, 5, 2], [2, 4, 3]];
            answer = 4;
            result = solution.MaxTwoEvents(events);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            events = [[1, 3, 2], [4, 5, 2], [1, 5, 5]];
            answer = 5;
            result = solution.MaxTwoEvents(events);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            events = [[1, 5, 3], [1, 5, 1], [6, 6, 5]];
            answer = 8;
            result = solution.MaxTwoEvents(events);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            events = [[66, 97, 90], [98, 98, 68], [38, 49, 63], [91, 100, 42], [92, 100, 22], [1, 77, 50], [64, 72, 97]];
            answer = 165;
            result = solution.MaxTwoEvents(events);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            events = [[19, 36, 24], [70, 90, 11], [61, 78, 36], [38, 38, 70], [39, 83, 72], [8, 46, 5], [64, 69, 49], [88, 89, 39], [53, 77, 24], [35, 76, 26]];
            answer = 142;
            result = solution.MaxTwoEvents(events);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
