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

            //5. 
            s = "2[abc]xyz3[cd]ef";
            answer = "abcabcxyzcdcdcdef";
            result = solution.DecodeString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            s = "2[2[ab]c]xyz3[cd]ef";
            answer = "ababcababcxyzcdcdcdef";
            result = solution.DecodeString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            s = "2[2[a3[x]b]c]xyz3[cd]ef";
            answer = "axxxbaxxxbcaxxxbaxxxbcxyzcdcdcdef";
            result = solution.DecodeString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
