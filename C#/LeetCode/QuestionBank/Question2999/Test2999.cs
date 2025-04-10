using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2999
{
    public class Test2999
    {
        public void Test()
        {
            Interface2999 solution = new Solution2999();
            long start, finish; int limit; string s;
            long result, answer;
            int id = 0;

            // 1. 
            start = 1; finish = 6000; limit = 4; s = "124";
            answer = 5;
            result = solution.NumberOfPowerfulInt(start, finish, limit, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            start = 15; finish = 215; limit = 6; s = "10";
            answer = 2;
            result = solution.NumberOfPowerfulInt(start, finish, limit, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            start = 1000; finish = 2000; limit = 4; s = "3000";
            answer = 0;
            result = solution.NumberOfPowerfulInt(start, finish, limit, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            start = 10; finish = 1844; limit = 5; s = "12";
            answer = 12;
            result = solution.NumberOfPowerfulInt(start, finish, limit, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            start = 15000; finish = 15001; limit = 9; s = "9";
            answer = 0;
            result = solution.NumberOfPowerfulInt(start, finish, limit, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            start = 3; finish = 1429; limit = 5; s = "34";
            answer = 10;
            result = solution.NumberOfPowerfulInt(start, finish, limit, s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
