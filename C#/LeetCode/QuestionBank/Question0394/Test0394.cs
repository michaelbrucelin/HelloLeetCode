using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0394
{
    public class Test0394
    {
        public void Test()
        {
            Interface0394 solution = new Solution0394();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "3[a]2[bc]";
            answer = "aaabcbc";
            result = solution.DecodeString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "3[a2[c]]";
            answer = "accaccacc";
            result = solution.DecodeString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3, 
            s = "2[abc]3[cd]ef";
            answer = "abcabccdcdcdef";
            result = solution.DecodeString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "abc3[cd]xyz";
            answer = "abccdcdcdxyz";
            result = solution.DecodeString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
