using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3440
{
    public class Test3440
    {
        public void Test()
        {
            Interface3440 solution = new Solution3440();
            int eventTime; int[] startTime, endTime;
            int result, answer;
            int id = 0;

            // 1. 
            eventTime = 5; startTime = [1, 3]; endTime = [2, 5];
            answer = 2;
            result = solution.MaxFreeTime(eventTime, startTime, endTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            eventTime = 10; startTime = [0, 7, 9]; endTime = [1, 8, 10];
            answer = 7;
            result = solution.MaxFreeTime(eventTime, startTime, endTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            eventTime = 10; startTime = [0, 3, 7, 9]; endTime = [1, 4, 8, 10];
            answer = 6;
            result = solution.MaxFreeTime(eventTime, startTime, endTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            eventTime = 5; startTime = [0, 1, 2, 3, 4]; endTime = [1, 2, 3, 4, 5];
            answer = 0;
            result = solution.MaxFreeTime(eventTime, startTime, endTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            eventTime = 405; startTime = [48, 84, 94, 335]; endTime = [55, 88, 113, 378];
            answer = 292;
            result = solution.MaxFreeTime(eventTime, startTime, endTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
