using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3714
{
    public class Test3714
    {
        public void Test()
        {
            Interface3714 solution = new Solution3714_off();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "abbac";
            answer = 4;
            result = solution.LongestBalanced(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aabcc";
            answer = 3;
            result = solution.LongestBalanced(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "aba";
            answer = 2;
            result = solution.LongestBalanced(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "accb";
            answer = 2;
            result = solution.LongestBalanced(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "bacbbc";
            answer = 4;
            result = solution.LongestBalanced(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
