using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0503
{
    public class Test0503
    {
        public void Test()
        {
            Interface0503 solution = new Solution0503_api();
            int num;
            int result, answer;
            int id = 0;

            // 1. 
            num = 1775;
            answer = 8;
            result = solution.ReverseBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = 7;
            answer = 4;
            result = solution.ReverseBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = 2147483647;
            answer = 32;
            result = solution.ReverseBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            num = 2147482622;
            answer = 30;
            result = solution.ReverseBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            num = -1;
            answer = 32;
            result = solution.ReverseBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
