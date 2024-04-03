using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3090
{
    public class Test3090
    {
        public void Test()
        {
            Interface3090 solution = new Solution3090_2();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "bcbbbcba";
            answer = 4;
            result = solution.MaximumLengthSubstring(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aaaa";
            answer = 2;
            result = solution.MaximumLengthSubstring(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
