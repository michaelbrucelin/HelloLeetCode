using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0552
{
    public class Test0552
    {
        public void Test()
        {
            Interface0552 solution = new Solution0552_3();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2;
            answer = 8;
            result = solution.CheckRecord(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 1;
            answer = 3;
            result = solution.CheckRecord(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 10101;
            answer = 183236316;
            result = solution.CheckRecord(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 21230;
            answer = 374793195;
            result = solution.CheckRecord(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
