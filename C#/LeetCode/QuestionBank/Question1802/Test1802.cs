using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1802
{
    public class Test1802
    {
        public void Test()
        {
            Interface1802 solution = new Solution1802_2();
            int n, index, maxSum;
            int result, answer;
            int id = 0;

            // 1. 
            n = 4; index = 2; maxSum = 6; answer = 2;
            result = solution.MaxValue(n, index, maxSum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 6; index = 1; maxSum = 10; answer = 3;
            result = solution.MaxValue(n, index, maxSum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 8; index = 7; maxSum = 14; answer = 4;
            result = solution.MaxValue(n, index, maxSum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 100; index = 1; maxSum = 108; answer = 4;
            result = solution.MaxValue(n, index, maxSum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 100; index = 98; maxSum = 108; answer = 4;
            result = solution.MaxValue(n, index, maxSum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6.
            n = 12123; index = 123; maxSum = 165321251; answer = 19576;
            result = solution.MaxValue(n, index, maxSum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 溢出测试
            n = 8257285; index = 4828516; maxSum = 850015631; answer = 29014;
            result = solution.MaxValue(n, index, maxSum);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
