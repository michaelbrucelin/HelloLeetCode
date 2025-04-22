using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2338
{
    public class Test2338
    {
        public void Test()
        {
            Interface2338 solution = new Solution2338();
            int n, maxValue;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2; maxValue = 5;
            answer = 10;
            result = solution.IdealArrays(n, maxValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5; maxValue = 3;
            answer = 11;
            result = solution.IdealArrays(n, maxValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 184; maxValue = 389;
            answer = 510488787;
            result = solution.IdealArrays(n, maxValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 5878; maxValue = 2900;
            answer = 465040898;
            result = solution.IdealArrays(n, maxValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 9767; maxValue = 9557;
            answer = 1998089;
            result = solution.IdealArrays(n, maxValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
