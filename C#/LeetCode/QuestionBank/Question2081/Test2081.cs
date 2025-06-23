using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2081
{
    public class Test2081
    {
        public void Test()
        {
            Interface2081 solution = new Solution2081();
            int k, n;
            long result, answer;
            int id = 0;

            // 1. 
            k = 2; n = 5;
            answer = 25;
            result = solution.KMirror(k, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            k = 3; n = 7;
            answer = 499;
            result = solution.KMirror(k, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            k = 7; n = 17;
            answer = 20379000;
            result = solution.KMirror(k, n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
