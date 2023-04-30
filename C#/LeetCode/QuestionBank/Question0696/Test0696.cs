using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0696
{
    public class Test0696
    {
        public void Test()
        {
            Interface0696 solution = new Solution0696();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "00110011"; answer = 6;
            result = solution.CountBinarySubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "10101"; answer = 4;
            result = solution.CountBinarySubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "00100"; answer = 2;
            result = solution.CountBinarySubstrings(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
