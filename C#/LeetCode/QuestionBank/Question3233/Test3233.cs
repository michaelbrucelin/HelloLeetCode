using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3233
{
    public class Test3233
    {
        public void Test()
        {
            Interface3233 solution = new Solution3233();
            int l, r;
            int result, answer;
            int id = 0;

            // 1. 
            l = 5; r = 7;
            answer = 3;
            result = solution.NonSpecialCount(l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            l = 4; r = 16;
            answer = 11;
            result = solution.NonSpecialCount(l, r);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
