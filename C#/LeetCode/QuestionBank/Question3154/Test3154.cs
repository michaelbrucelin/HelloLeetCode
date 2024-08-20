using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3154
{
    public class Test3154
    {
        public void Test()
        {
            Interface3154 solution = new Solution3154();
            int k;
            int result, answer;
            int id = 0;

            // 1. 
            k = 0;
            answer = 2;
            result = solution.WaysToReachStair(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            k = 1;
            answer = 4;
            result = solution.WaysToReachStair(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            k = 2;
            answer = 4;
            result = solution.WaysToReachStair(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            k = 3;
            answer = 3;
            result = solution.WaysToReachStair(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            k = 13;
            answer = 10;
            result = solution.WaysToReachStair(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            k = 4084;
            answer = 13;
            result = solution.WaysToReachStair(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            k = 1048556;
            answer = 21;
            result = solution.WaysToReachStair(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
