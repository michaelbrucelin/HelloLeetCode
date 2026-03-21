using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0076
{
    public class Test0076
    {
        public void Test()
        {
            Interface0076 solution = new Solution0076();
            string s, t;
            string result, answer;
            int id = 0;

            // 1. 
            s = "ADOBECODEBANC"; t = "ABC";
            answer = "BANC";
            result = solution.MinWindow(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "a"; t = "a";
            answer = "a";
            result = solution.MinWindow(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "a"; t = "aa";
            answer = "";
            result = solution.MinWindow(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
