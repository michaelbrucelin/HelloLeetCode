using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0151
{
    public class Test0151
    {
        public void Test()
        {
            Interface0151 solution = new Solution0151_2();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "the sky is blue"; answer = "blue is sky the";
            result = solution.ReverseWords(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "  hello  world  "; answer = "world hello";
            result = solution.ReverseWords(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "a good   example"; answer = "example good a";
            result = solution.ReverseWords(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
