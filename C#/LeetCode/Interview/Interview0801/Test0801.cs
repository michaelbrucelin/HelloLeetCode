using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0801
{
    public class Test0801
    {
        public void Test()
        {
            Interface0801 solution = new Solution0801_2();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 3;
            answer = 4;
            result = solution.WaysToStep(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5;
            answer = 13;
            result = solution.WaysToStep(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 80;
            answer = 997451737;
            result = solution.WaysToStep(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 1000000;
            answer = 746580045;
            result = solution.WaysToStep(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
