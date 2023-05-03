using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1003
{
    public class Test1003
    {
        public void Test()
        {
            Interface1003 solution = new Solution1003();
            string s;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "aabcbc"; answer = true;
            result = solution.IsValid(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "abcabcababcc"; answer = true;
            result = solution.IsValid(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "abccba"; answer = false;
            result = solution.IsValid(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
