using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3258
{
    public class Test3258
    {
        public void Test()
        {
            Interface3258 solution = new Solution3258();
            string s; int k;
            int result, answer;
            int id = 0;

            // 1. 
            s = "10101"; k = 1;
            answer = 12;
            result = solution.CountKConstraintSubstrings(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "1010101"; k = 2;
            answer = 25;
            result = solution.CountKConstraintSubstrings(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "11111"; k = 1;
            answer = 15;
            result = solution.CountKConstraintSubstrings(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "000011"; k = 1;
            answer = 18;
            result = solution.CountKConstraintSubstrings(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
