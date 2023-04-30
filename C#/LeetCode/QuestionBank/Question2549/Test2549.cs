using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2549
{
    public class Test2549
    {
        public void Test()
        {
            Interface2549 solution = new Solution2549();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 5; answer = 4;
            result = solution.DistinctIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; answer = 2;
            result = solution.DistinctIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1; answer = 1;
            result = solution.DistinctIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 10; answer = 9;
            result = solution.DistinctIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 23; answer = 22;
            result = solution.DistinctIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 33; answer = 32;
            result = solution.DistinctIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            n = 88; answer = 87;
            result = solution.DistinctIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            n = 100; answer = 99;
            result = solution.DistinctIntegers(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
