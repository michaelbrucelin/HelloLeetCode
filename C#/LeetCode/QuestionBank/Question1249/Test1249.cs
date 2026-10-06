using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1249
{
    public class Test1249
    {
        public void Test()
        {
            Interface1249 solution = new Solution1249();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "lee(t(c)o)de)";
            answer = "lee(t(c)o)de";
            result = solution.MinRemoveToMakeValid(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "a)b(c)d";
            answer = "ab(c)d";
            result = solution.MinRemoveToMakeValid(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3 .
            s = "))((";
            answer = "";
            result = solution.MinRemoveToMakeValid(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
