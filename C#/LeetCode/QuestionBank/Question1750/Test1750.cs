using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1750
{
    public class Test1750
    {
        public void Test()
        {
            Interface1750 solution = new Solution1750();
            string s;
            int result, answer;
            int id = 0;

            // 1.
            s = "ca"; answer = 2;
            result = solution.MinimumLength(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            s = "cabaabac"; answer = 0;
            result = solution.MinimumLength(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            s = "aabccabba"; answer = 3;
            result = solution.MinimumLength(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            s = "a"; answer = 1;
            result = solution.MinimumLength(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
