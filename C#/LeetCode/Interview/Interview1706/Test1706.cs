using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1706
{
    public class Test1706
    {
        public void Test()
        {
            Interface1706 solution = new Solution1706();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2;
            answer = 1;
            result = solution.NumberOf2sInRange(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 25;
            answer = 9;
            result = solution.NumberOf2sInRange(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 100;
            answer = 20;
            result = solution.NumberOf2sInRange(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 32345;
            answer = 23121;
            result = solution.NumberOf2sInRange(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 1000000000;
            answer = 900000000;
            result = solution.NumberOf2sInRange(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
