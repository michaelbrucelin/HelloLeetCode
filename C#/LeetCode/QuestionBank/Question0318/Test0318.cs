using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0318
{
    public class Test0318
    {
        public void Test()
        {
            Interface0318 solution = new Solution0318();
            string[] words;
            int result, answer;
            int id = 0;

            // 1. 
            words = new string[] { "abcw", "baz", "foo", "bar", "xtfn", "abcdef" };
            answer = 16;
            result = solution.MaxProduct(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = new string[] { "a", "ab", "abc", "d", "cd", "bcd", "abcd" };
            answer = 4;
            result = solution.MaxProduct(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            words = new string[] { "a", "aa", "aaa", "aaaa" };
            answer = 0;
            result = solution.MaxProduct(words);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
