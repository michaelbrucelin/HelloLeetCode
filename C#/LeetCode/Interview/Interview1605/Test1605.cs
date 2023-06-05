using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1605
{
    public class Test1605
    {
        public void Test()
        {
            Interface1605 solution = new Solution1605();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 3; answer = 0;
            result = solution.TrailingZeroes(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 16; answer = 3;
            result = solution.TrailingZeroes(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 32; answer = 7;
            result = solution.TrailingZeroes(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 108; answer = 25;
            result = solution.TrailingZeroes(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 12345678; answer = 3086416;
            result = solution.TrailingZeroes(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 2147483647; answer = 536870902;
            result = solution.TrailingZeroes(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
